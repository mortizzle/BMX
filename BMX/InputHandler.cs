using System.Windows.Forms;

namespace BMX
{
    internal static class InputHandler
    {
        public static void HandleMouseClick(MouseEventArgs e, GameState gameState)
        {
            gameState.Reset();
        }

        public static void HandleKeyPress(KeyPressEventArgs e, GameState gameState)
        {
            gameState.Reset();
        }
    }
}
