using BMX.Engine.Interfaces;
using BMX.Models;
using BMX.UI.Interfaces;

namespace BMX.Actions
{
    internal class NewGameAction : IAction
    {
        private readonly IMenuFactory _menuFactory;

        public NewGameAction(IMenuFactory menuFactory)
        {
            _menuFactory = menuFactory;
        }

        public ApplicationState Execute(ApplicationState state)
        {
            return state with
            {
                UIState = state.UIState with
                {
                    Menus = state.UIState.Menus.Add(_menuFactory.CreateToolbar())
                }
            };
        }
    }
}
