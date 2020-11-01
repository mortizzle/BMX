using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Windows.Forms;

namespace BMX
{
    internal static class Renderer
    {
        public static void Render(SKPaintSurfaceEventArgs e, GameState gameState)
        {
            e.Surface.Canvas.Clear(SKColors.LightGreen);
            foreach(var trackSegment in gameState.TrackSegments)
            {
                e.Surface.Canvas.DrawText($"{trackSegment.Type}", trackSegment.Position.X, trackSegment.Position.Y, new SKPaint() { Color = SKColors.Black, TextSize = 25 });
            }

            foreach(var bmx in gameState.Bmxes)
            {
                e.Surface.Canvas.DrawText("B", bmx.Position.X, bmx.Position.Y, new SKPaint() { Color = SKColors.Black, TextSize = 25 });
            }
        }
    }
}
