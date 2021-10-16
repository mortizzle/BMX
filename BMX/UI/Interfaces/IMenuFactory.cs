using BMX.UI.Models;

namespace BMX.UI.Interfaces
{
    public interface IMenuFactory
    {
        MenuState CreateMainMenu();
        MenuState CreateToolbar();
    }
}
