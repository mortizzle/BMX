using BMX.Engine.Interfaces;
using System.Windows.Forms;

namespace BMX.Engine
{
    internal class InputHandler: IInputHandler
    {
        public GameState HandleMouseClick(MouseEventArgs e, GameState gameState)
        {
            return e.Button switch
            {
                MouseButtons.Left => gameState,
                MouseButtons.Right => gameState,
                _ => throw new System.NotImplementedException()
            };
        }

        public GameState HandleKeyPress(KeyPressEventArgs e, GameState gameState)
        {
            return e.KeyChar switch
            {
                ' ' => gameState,
                'p' => gameState,
                _ => gameState
            };
        }
    }
}
