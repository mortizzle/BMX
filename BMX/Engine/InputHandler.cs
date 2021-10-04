using BMX.Engine.Interfaces;
using BMX.Models;
using System.Windows.Forms;

namespace BMX.Engine
{
    internal class InputHandler: IInputHandler
    {
        public ApplicationState HandleMouseClick(MouseEventArgs e, ApplicationState gameState)
        {
            return e.Button switch
            {
                MouseButtons.Left => gameState,
                MouseButtons.Right => gameState,
                _ => throw new System.NotImplementedException()
            };
        }

        public ApplicationState HandleKeyPress(KeyPressEventArgs e, ApplicationState gameState)
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
