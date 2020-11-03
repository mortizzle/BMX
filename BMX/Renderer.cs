using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BMX
{
    internal static class Renderer
    {
        public static void Render(SKPaintSurfaceEventArgs e, GameState gameState)
        {
            e.Surface.Canvas.Clear(SKColors.LightGreen);

            var firstBmx = gameState.Bmxes.FirstOrDefault();
            e.Surface.Canvas.DrawText($"Debug", 20, 20, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
            e.Surface.Canvas.DrawText($"Game ticks elapsed: {gameState.GameTicks}", 20, 40, new SKPaint() { Color = SKColors.Black, TextSize=15, IsAntialias = true });

            if (firstBmx != null)
            {
                e.Surface.Canvas.DrawText($"Bmx Position: {firstBmx.Position}", 20, 60, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
                e.Surface.Canvas.DrawText($"Bmx Target: {firstBmx.TargetPoint}", 20, 80, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
                e.Surface.Canvas.DrawText($"Bmx Bearing: {firstBmx.FrameBearing}", 20, 100, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
                e.Surface.Canvas.DrawText($"Bmx Handlebar Angle: {firstBmx.HandleBarsAngle}", 20, 120, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
                e.Surface.Canvas.DrawText($"Bearing to target: {GameEngine.AngleBetweenTwoPoints(firstBmx.Position, firstBmx.TargetPoint)}", 20, 140, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
            }

            e.Surface.Canvas.DrawText($"{gameState.GameSpeed} Speed", 1600, 50, new SKPaint() { Color = SKColors.Black, TextSize = 50, IsAntialias = true });

            if (gameState.Paused)
            {
                e.Surface.Canvas.DrawText("PAUSED", 1600, 100, new SKPaint() { Color = SKColors.Red, TextSize = 50, IsAntialias = true });
            }

            foreach (var trackSegment in gameState.TrackSegments)
            {
                var colour = GetColourForTrackType(trackSegment.Type);
                if (trackSegment.Position == firstBmx?.TargetPoint) colour = SKColors.Blue;

                e.Surface.Canvas.DrawCircle(trackSegment.Position.X, trackSegment.Position.Y, 5, new SKPaint() { Color = colour, Style = SKPaintStyle.Fill, IsAntialias = true });
            }

            foreach(var bmx in gameState.Bmxes)
            {
                BmxRenderer.Render(e.Surface.Canvas, bmx);
            }
        }

        private static SKColor GetColourForTrackType(TrackType type)
        {
            return type switch
            {
                TrackType.StartLine => SKColors.DarkGreen,
                TrackType.Straight => SKColors.Black,
                TrackType.FinishLine => SKColors.DarkRed,
                _ => throw new NotImplementedException(),
            };
        }

    }
}
