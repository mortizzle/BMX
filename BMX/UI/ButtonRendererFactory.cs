using System;
using BMX.Drawing;
using SkiaSharp;

namespace BMX.UI
{
    internal static class ButtonRendererFactory
    {
        public static Action<SKCanvas> CreateTextButtonRenderer(int width, int height, string text, int textSize)
        {
            return (SKCanvas canvas) =>
            {
                canvas.DrawRoundRect(0, 0, width, height, 10, 10, PaintPresets.ButtonBackground);

                var textPaint = PaintPresets.ButtonText;
                textPaint.TextSize = textSize;

                var textSizeInPx = textPaint.TextSize * 72 / 96; // Points to pixel conversion

                var textY = height / 2 + textSizeInPx / 2;
                var textX = width / 2 - (text.Length * textSizeInPx * 0.45f); // Not quite right but good enough
                canvas.DrawText(text, textX, textY, textPaint);
            };
        }

        internal static Action<SKCanvas> CreateCurvedTrackRenderer()
        {
            var radius = 50;
            return (SKCanvas canvas) =>
            {
                var shader = SKShader.CreateRadialGradient(new SKPoint(0, 0),
                                                   2*radius,
                                                   new [] { SKColors.LightGreen, SKColors.Brown, SKColors.SandyBrown, SKColors.SandyBrown, SKColors.Brown, SKColors.LightGreen },
                                                   new [] { 0.1f, 0.15f, 0.2f, 0.80f, 0.85f, 0.9f },
                                                   SKShaderTileMode.Clamp);

                var paint = new SKPaint
                {
                    Shader = shader
                };

                canvas.DrawRect(0, 0, radius*2, radius*2, paint);
            };
        }
    }
}
