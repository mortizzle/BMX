using System.Windows.Forms;

namespace BMX.Engine.Interfaces
{
    internal interface IInputHandler
    {
        GameState HandleMouseClick(MouseEventArgs e, GameState gameState);
        GameState HandleKeyPress(KeyPressEventArgs e, GameState gameState);
    }
}