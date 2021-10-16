using BMX.Models;

namespace BMX.Engine.Interfaces
{
    internal interface IAction
    {
        ApplicationState Execute(ApplicationState state);  
    }
}
