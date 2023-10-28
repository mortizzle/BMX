using BMX.Engine.Interfaces;
using BMX.Models;
using BMX.UI.Models;
using System.Drawing;

namespace BMX.Engine
{
    internal class InputHandler: IInputHandler
    {
        public ApplicationState HandleMouseClick(MouseButton mouseButton, int mouseX, int mouseY, ApplicationState applicationState)
        {

            var menus = applicationState.UIState.Menus;
            foreach(var menu in menus.Reverse())
            {
                if (MenuContainsPoint(menu, new Point(mouseX, mouseY)))
                {
                    var relativeLocation = new Point
                    {
                        X = mouseX - menu.XPos,
                        Y = mouseY - menu.YPos
                    };
                    return HandleMenuClick(menu, relativeLocation, mouseButton, applicationState);
                }
            }

            return applicationState;
        }

        private ApplicationState HandleMenuClick(MenuState menu, Point location, MouseButton clickType, ApplicationState applicationState)
        {
            foreach(var button in menu.Buttons)
            {
                if (ButtonContainsPoint(button, location))
                {
                    return button.OnClick(applicationState);
                }
            }
            return applicationState;
        }

        private bool ButtonContainsPoint(ButtonState button, Point location)
        {
            var minX = button.XPos;
            var maxX = minX + button.Width;
            var minY = button.YPos;
            var maxY = minY + button.Height;

            return RectangleContainsPoint(minX, maxX, minY, maxY, location);
        }

        public ApplicationState HandleKeyPress(char keyPressed, ApplicationState applicationState)
        {
            return keyPressed switch
            {
                ' ' => applicationState,
                'p' => applicationState,
                _ => applicationState
            };
        }

        private bool MenuContainsPoint(MenuState menu, Point point)
        {
            var minX = menu.XPos;
            var maxX = minX + menu.Width;
            var minY = menu.YPos;
            var maxY = minY + menu.Height;

            return RectangleContainsPoint(minX, maxX, minY, maxY, point);
        }

        private bool RectangleContainsPoint(int rectX1, int rectX2, int rectY1, int rectY2, Point point)
        {
            return (point.X >= rectX1 && point.X <= rectX2 && point.Y >= rectY1 && point.Y <= rectY2);
        }
    }
}
