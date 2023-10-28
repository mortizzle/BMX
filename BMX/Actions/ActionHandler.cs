using BMX.Models;
using BMX.UI;
using System.Collections.Immutable;

namespace BMX.Actions
{
    internal static class ActionHandler 
    {
        public static ApplicationState HandleNewGame(ApplicationState state)
        {
            return state with
            {
                UIState = state.UIState with
                {
                    Menus = ImmutableList.Create(MenuFactory.CreateToolbar())
                }
            };
        }
    }
}
