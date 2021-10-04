using BMX.Models;
using System.Windows.Forms;

namespace BMX.Engine.Interfaces
{
    internal interface IInputHandler
    {
        ApplicationState HandleMouseClick(MouseEventArgs e, ApplicationState gameState);
        ApplicationState HandleKeyPress(KeyPressEventArgs e, ApplicationState gameState);
    }
}