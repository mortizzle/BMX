using BMX.Actions;
using BMX.UI.Models;
using System.Collections.Immutable;

namespace BMX.UI
{
    public static class MenuFactory
    {
        public static MenuState CreateMainMenu()
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
                    Render = ButtonRendererFactory.CreateTextButtonRenderer(width: 200, height: 50,text: "New Game", textSize: 23),
                    OnClick = ActionHandler.HandleNewGame
                })
            };
        }

        public static MenuState CreateToolbar()
        {
            return new MenuState
            {
                XPos = 10,
                YPos = 25,

                Width = 150,
                Height = 1000,

                Buttons = ImmutableList.Create(new ButtonState
                {
                    XPos = 25,
                    YPos = 25,
                    Width = 100,
                    Height = 100,
                    Render = ButtonRendererFactory.CreateCurvedTrackRenderer()
                })
            };
        }
    }
}
