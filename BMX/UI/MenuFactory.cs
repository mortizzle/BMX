using BMX.UI.Interfaces;
using BMX.UI.Models;
using System.Collections.Immutable;

namespace BMX.UI
{
    internal class MenuFactory : IMenuFactory
    {
        public MenuState CreateMainMenu()
        {
            return new MenuState
            {
                XPos = 700,
                YPos = 150,

                Width = 500,
                Height = 800,

                Buttons = ImmutableList.Create(new ButtonState
                {
                    XPos = 150,
                    YPos = 100,
                    Width = 200,
                    Height = 50,
                    Text = "New Game",
                    TextSize = 23,
                    ActionType = ActionType.NewGame
                })
            };
        }

        public MenuState CreateToolbar()
        {
            return new MenuState
            {
                XPos = 0,
                YPos = 0,

                Width = 300,
                Height = 1000,

                Buttons = ImmutableList.Create(new ButtonState
                {
                    XPos = 150,
                    YPos = 100,
                    Width = 200,
                    Height = 50,
                    Text = "Test",
                    TextSize = 23
                })
            };
        }
    }
}
