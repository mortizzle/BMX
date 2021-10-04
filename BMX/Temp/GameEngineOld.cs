using BMX.Models;
using System;
using System.Numerics;

namespace BMX
{
    internal static class GameEngineOld
    {
        private const int BikeDistancePerTick = 5;
        private const int MaxHandleBarTurnInDegrees = 37; // Max turning angle of a bmx. Source - googling
        private const int CasterAngle = 22; // BMX generally have caster angle of between 21 and 24 degrees. Source - googling

        public static GameStateOld UpdateGameState(GameStateOld gameState)
        {
            if (gameState.Paused) return gameState;

            gameState.GameTicks++;
            //return gameState with { X = gameState.X + new Random().Next(20) - 10, Y = gameState.Y + new Random().Next(20) - 10 };
            foreach(var bmx in gameState.Bmxes)
            {
                MoveBMXInCurrentDirection(bmx, BikeDistancePerTick);
                if (Vector2.Distance(bmx.Position, bmx.TargetPoint) <= BikeDistancePerTick)
                {
                    var found = false;
                    foreach(var trackSegment in gameState.TrackSegments)
                    {
                        if (found)
                        {
                            bmx.TargetPoint = trackSegment.Position;
                            break;
                        }

                        if (trackSegment.Position == bmx.TargetPoint)
                        {
                            found = true;
                        }

                    }
                }

                TurnHandleBarsTowardsTargetPoint(bmx);
            }

            return gameState;
        }

        internal static int GetTickLength(GameState gameState)
        {
            return gameState.GameSpeed switch
            {
                GameSpeed.Snail => 500,
                GameSpeed.Slow => 150,
                GameSpeed.Normal => 16,
                _ => throw new NotImplementedException(),
            };
        }

        private static void TurnHandleBarsTowardsTargetPoint(Bmx bmx)
        {
            var bearingToTarget = bmx.Position.BearingTo(bmx.TargetPoint);

            var handleBarsAngle = TurnHandleBarsTowardsBearing(bmx, bearingToTarget);

            bmx.HandleBarsAngle = handleBarsAngle;
        }

        internal static double TurnHandleBarsTowardsBearing(Bmx bmx, double bearing)
        {
            var handleBarAngle = bearing - bmx.FrameBearing;
            if (handleBarAngle > 180) handleBarAngle -= 360;
            if (handleBarAngle < -180) handleBarAngle += 360;

            if (handleBarAngle > MaxHandleBarTurnInDegrees) handleBarAngle = MaxHandleBarTurnInDegrees;
            if (handleBarAngle < -MaxHandleBarTurnInDegrees) handleBarAngle = -MaxHandleBarTurnInDegrees;

            return handleBarAngle;
        }

        private static void MoveBMXInCurrentDirection(Bmx bmx, int distanceToMove)
        {
            // Calculate new point
            var straightLineBearing = bmx.FrameBearing; 
            var straightLineDistanceTravelled = (double) distanceToMove;
            var amountRotatedInDegrees = (double) 0;

            var turningCircleRadius = CalculateTurnRadius(bmx);
            if (!double.IsInfinity(turningCircleRadius))
            {
                amountRotatedInDegrees = 180 * distanceToMove / (System.Math.PI * turningCircleRadius);

                straightLineDistanceTravelled = 2 * turningCircleRadius * Math.Sine(amountRotatedInDegrees / 2) ;
                straightLineBearing += amountRotatedInDegrees / 2;
            }

            var deltaX = straightLineDistanceTravelled * Math.Cosine(straightLineBearing); // Cos = adj/hyp => adj = hyp * cos
            var deltaY = straightLineDistanceTravelled * Math.Sine(straightLineBearing); // Sin = opp/hyp => opp = hyp * sin
            var deltaVector = new Vector2((int)-deltaX, (int)-deltaY);
            
            var newFrameBearing = bmx.FrameBearing + amountRotatedInDegrees;
            var newPosition = Vector2.Add(bmx.Position, deltaVector);

            bmx.FrameBearing = newFrameBearing;
            bmx.Position = newPosition;
        }

       

        private static double CalculateTurnRadius(Bmx bmx)
        {
            // Angles may need to be changed to radians
            var steerAngle = Math.DegreesToRadians(bmx.HandleBarsAngle);
            var wheelBase = 20; // This is determined by how far apart wheel centers are in rendering, we need to abstract this out

            return wheelBase / (steerAngle * Math.Cosine(CasterAngle)); // This should give an approximation of radius according to https://en.wikipedia.org/wiki/Bicycle_and_motorcycle_dynamics
        }

        private static Vector2 MoveXDistanceFromPointAToPointB(int distance, Vector2 pointA, Vector2 pointB)
        {
            var distanceStraightLine = Vector2.Distance(pointA, pointB);
            var ratio = distance / distanceStraightLine;

            var diffVector = pointB - pointA;
            var scaledDiffDector = Vector2.Multiply(diffVector, ratio);

            return Vector2.Add(pointA, scaledDiffDector);
        }


    }
}
