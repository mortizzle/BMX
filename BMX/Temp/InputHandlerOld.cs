using BMX.Engine.Interfaces;
using BMX.Models;
using BMX.UI.Models;
using System.Linq;
using System.Numerics;

namespace BMX.Engine
{
    internal static class InputHandlerOld
    {
        public static GameStateOld HandleMouseClick(MouseButton mouseButton, float mouseX, float mouseY, GameStateOld gameState)
        {
            return mouseButton switch
            {
                MouseButton.Left => gameState.WithAdditionalTrackSegment(new TrackSegment { Position = new Vector2(mouseX, mouseY), Type = TrackType.Straight }),
                MouseButton.Right => gameState.WithAdditionalTrackSegment(new TrackSegment { Position = new Vector2(mouseX, mouseY), Type = TrackType.FinishLine }),
                _ => throw new System.NotImplementedException()
            };
        }

        public static GameStateOld HandleKeyPress(char keyPressed, float keyX, float keyY, GameStateOld gameState)
        {
            return keyPressed switch
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
