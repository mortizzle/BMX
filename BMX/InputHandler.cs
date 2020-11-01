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
                _ => gameState
            };
        }
    }
}
