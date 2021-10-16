using BMX.Models;
using BMX.UI.Models;

namespace BMX.Engine.Interfaces
{
    public interface IInputHandler
    {
        ApplicationState HandleMouseClick(MouseButton mouseButton, int mouseX, int mouseY, ApplicationState applicationState);
        ApplicationState HandleKeyPress(char keyPressed, ApplicationState gameState);
    }
}