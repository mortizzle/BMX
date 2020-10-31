using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace BMX
{
    internal static class Renderer
    {
        public static void Render(SKPaintSurfaceEventArgs e, GameState gameState)
        {
            e.Surface.Canvas.Clear(SKColors.Green);

            e.Surface.Canvas.DrawText($"{gameState.X},{gameState.Y}", 200, 200, new SKPaint() { Color = SKColors.Black, TextSize = 25 });
            e.Surface.Canvas.DrawText("X", gameState.X, gameState.Y, new SKPaint() { Color = SKColors.Black, TextSize = 25 });
        }
    }
}
