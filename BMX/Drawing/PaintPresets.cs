using SkiaSharp;

namespace BMX.Drawing
{
    internal static class PaintPresets
    {
        public static SKPaint MenuBackground = new SKPaint()
        {
            Color = SKColors.Gray,
            Style = SKPaintStyle.Fill,
            IsAntialias = true
        };

        public static SKPaint MenuBackgroundBorder = new SKPaint()
        {
            Color = SKColors.DarkGray,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 6,
            IsAntialias = true
        };

        public static SKPaint ButtonBackground = new SKPaint()
        {
            Color = SKColors.Gray,
            Style = SKPaintStyle.Fill,
            IsAntialias = true
        };

        public static SKPaint ButtonShadowBorder = new SKPaint()
        {
            Color = SKColors.DarkGray,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 4,
            IsAntialias = true
        };

        public static SKPaint ButtonHighlightBorder = new SKPaint()
        {
            Color = SKColors.LightGray,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 4,
            IsAntialias = true
        };

        public static SKPaint ButtonText = new SKPaint()
        {
            Color = SKColors.Black,
            Style = SKPaintStyle.Fill,
            IsAntialias = true
        };
    }
}
