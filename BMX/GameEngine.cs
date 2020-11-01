using System;
using System.Numerics;

namespace BMX
{
    internal static class GameEngine
    {
        private const int BikeDistancePerTick = 5;
        public static GameState UpdateGameState(GameState gameState)
        {
            //return gameState with { X = gameState.X + new Random().Next(20) - 10, Y = gameState.Y + new Random().Next(20) - 10 };
            foreach(var bmx in gameState.Bmxes)
            {
                var currPosition = bmx.Position;
                var destPosition = bmx.TargetPoint;

                var newPoint = MoveXDistanceFromPointAToPointB(BikeDistancePerTick, currPosition, destPosition);
                if (Vector2.Distance(newPoint, destPosition) <= BikeDistancePerTick)
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

                bmx.Position = newPoint;
            }

            return gameState;
        }

        private static Vector2 MoveXDistanceFromPointAToPointB(int distance, Vector2 pointA, Vector2 pointB)
        {
            var distanceStraightLine = Vector2.Distance(pointA, pointB);
            var ratio = distance / distanceStraightLine;

            var diffVector = pointB - pointA;
            var scaledDiffDector = Vector2.Multiply(diffVector, ratio);

            return Vector2.Add(pointA, scaledDiffDector);
        }

        private static double DistanceBetweenTwoPoints(int x1, int y1, int x2, int y2)
        {
            var xDiff = x1 - x2;
            var yDiff = y1 - y2;

            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }
    }
}
