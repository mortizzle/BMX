using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace BMX
{
    internal static class InputHandler
    {
        public static GameState HandleMouseClick(MouseEventArgs e, GameState gameState)
        {
            return e.Button switch
            {
                MouseButtons.Left => gameState.WithAdditionalTrackSegment(new TrackSegment { Position = new Vector2(e.X, e.Y), Type = TrackType.Straight }),
                MouseButtons.Right => gameState.WithAdditionalTrackSegment(new TrackSegment { Position = new Vector2(e.X, e.Y), Type = TrackType.FinishLine }),
                _ => throw new System.NotImplementedException()
            };
        }

        public static GameState HandleKeyPress(KeyPressEventArgs e, GameState gameState)
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

        private static GameState IncreaseSpeed(GameState gameState) 
        {
            var currentSpeed = gameState.GameSpeed;
            if (currentSpeed == GameSpeed.Normal) return gameState;

            return gameState with { GameSpeed = currentSpeed + 1 };
        }

        private static GameState DecreaseSpeed(GameState gameState)
        {
            var currentSpeed = gameState.GameSpeed;
            if (currentSpeed == GameSpeed.Snail) return gameState;

            return gameState with { GameSpeed = currentSpeed - 1 };
        }
    }
}
