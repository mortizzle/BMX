using SkiaSharp;

namespace BMX.Drawing
{
    public static class PaintPresets
    {
        public static SKPaint MenuBackground = new SKPaint()
        {
            Color = SKColors.DarkGray.WithAlpha(0xD0),
            Style = SKPaintStyle.Fill,
            IsAntialias = true,
            
        };

        public static SKPaint ButtonBackground = new SKPaint()
        {
            Color = SKColors.Gray.WithAlpha(0xD0),
            Style = SKPaintStyle.Fill,
            IsAntialias = true
        };

        public static SKPaint ButtonText = new SKPaint()
        {
            Color = SKColors.Black.WithAlpha(0xD0),
            Style = SKPaintStyle.Fill,
            IsAntialias = true
        };
    }
}
