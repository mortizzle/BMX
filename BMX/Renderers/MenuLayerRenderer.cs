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
            canvas.DrawRect(0, 0, menuState.Width, menuState.Height, PaintPresets.MenuBackground);
            canvas.DrawRect(0, 0, menuState.Width, menuState.Height, PaintPresets.MenuBackgroundBorder);

            menuState.Buttons.ForEach(buttonState => canvas.At(buttonState.XPos, buttonState.YPos, (canvas) => RenderButton(canvas, buttonState)));
        }

        private void RenderButton(SKCanvas canvas, ButtonState buttonState)
        {
            canvas.DrawRect(0, 0, buttonState.Width, buttonState.Height, PaintPresets.ButtonBackground);

            canvas.DrawLine(0, 0, buttonState.Width, 0, PaintPresets.ButtonShadowBorder);
            canvas.DrawLine(0, 0, 0, buttonState.Height, PaintPresets.ButtonShadowBorder);

            canvas.DrawLine(buttonState.Width, 0, buttonState.Width, buttonState.Height, PaintPresets.ButtonHighlightBorder);
            canvas.DrawLine(0, buttonState.Height, buttonState.Width, buttonState.Height, PaintPresets.ButtonHighlightBorder);

            var textPaint = PaintPresets.ButtonText;
            textPaint.TextSize = buttonState.TextSize;

            var textSizeInPx = textPaint.TextSize * 72 / 96; // Points to pixel conversion

            var textY = buttonState.Height / 2 + textSizeInPx/2;
            var textX = buttonState.Width / 2 - (buttonState.Text.Length * textSizeInPx * 0.45f); // Not quite right but good enough
            canvas.DrawText(buttonState.Text, textX, textY, textPaint);
        }
    }
}
