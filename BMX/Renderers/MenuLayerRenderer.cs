using BMX.Drawing;
using BMX.Models;
using BMX.Renderers.Interfaces;
using BMX.UI.Models;
using SkiaSharp;

namespace BMX.Renderers
{
    internal class MenuLayerRenderer : ILayerRenderer
    {
        public int ZLevel() => 99;

        public void Render(SKCanvas canvas, ApplicationState applicationState)
        {
            applicationState.UIState.Menus.ForEach(menuState => canvas.At(menuState.XPos, menuState.YPos, (canvas) => RenderMenu(canvas, menuState)));
        }

        private void RenderMenu(SKCanvas canvas, MenuState menuState)
        {
            canvas.DrawRoundRect(0, 0, menuState.Width, menuState.Height, 10,10, PaintPresets.MenuBackground);

            menuState.Buttons.ForEach(buttonState => canvas.At(buttonState.XPos, buttonState.YPos, (canvas) => RenderButton(canvas, buttonState)));
        }

        private void RenderButton(SKCanvas canvas, ButtonState buttonState)
        {
            canvas.Save();
            canvas.ClipRoundRect(new SKRoundRect(new SKRect(0,0,buttonState.Width, buttonState.Height), 10));
            buttonState.Render(canvas);
            canvas.DrawRoundRect(new SKRoundRect(new SKRect(0, 0, buttonState.Width, buttonState.Height), 10), PaintPresets.ButtonBorder);
            canvas.Restore();
        }
    }
}
