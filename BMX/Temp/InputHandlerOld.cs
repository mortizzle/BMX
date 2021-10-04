using BMX.Engine.Interfaces;
using BMX.Models;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace BMX.Engine
{
    internal static class InputHandlerOld
    {
        public static GameStateOld HandleMouseClick(MouseEventArgs e, GameStateOld gameState)
        {
            return e.Button switch
            {
                MouseButtons.Left => gameState.WithAdditionalTrackSegment(new TrackSegment { Position = new Vector2(e.X, e.Y), Type = TrackType.Straight }),
                MouseButtons.Right => gameState.WithAdditionalTrackSegment(new TrackSegment { Position = new Vector2(e.X, e.Y), Type = TrackType.FinishLine }),
                _ => throw new System.NotImplementedException()
            };
        }

        public static GameStateOld HandleKeyPress(KeyPressEventArgs e, GameStateOld gameState)
        {
            return e.KeyChar switch
            {
                ' ' => gameState.WithAdditionalBmxes(new Bmx { Position = gameState.TrackSegments.First().Position, TargetPoint = gameState.TrackSegments.Skip(1).First().Position }),
                'p' => gameState with { Paused = !gameState.Paused },
                '+' => IncreaseSpeed(gameState),
                '-' => DecreaseSpeed(gameState),
                _ => gameState
            };
        }

        private static GameStateOld IncreaseSpeed(GameStateOld gameState) 
        {
            var currentSpeed = gameState.GameSpeed;
            if (currentSpeed == GameSpeed.Normal) return gameState;

            return gameState with { GameSpeed = currentSpeed + 1 };
        }

        private static GameStateOld DecreaseSpeed(GameStateOld gameState)
        {
            var currentSpeed = gameState.GameSpeed;
            if (currentSpeed == GameSpeed.Snail) return gameState;

            return gameState with { GameSpeed = currentSpeed - 1 };
        }
    }
}
