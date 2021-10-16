using SkiaSharp;
using System;
using System.Linq;

namespace BMX.Engine
{
    internal static class RendererOld
    {
        public static void Render(SKCanvas canvas, GameStateOld gameState)
        {
            canvas.Clear(SKColors.LightGreen);

            var firstBmx = gameState.Bmxes.FirstOrDefault();
            canvas.DrawText($"Debug", 20, 20, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
            canvas.DrawText($"Game ticks elapsed: {gameState.GameTicks}", 20, 40, new SKPaint() { Color = SKColors.Black, TextSize=15, IsAntialias = true });

            if (firstBmx != null)
            {
                canvas.DrawText($"Bmx Position: {firstBmx.Position}", 20, 60, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
                canvas.DrawText($"Bmx Target: {firstBmx.TargetPoint}", 20, 80, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
                canvas.DrawText($"Bmx Bearing: {firstBmx.FrameBearing}", 20, 100, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
                canvas.DrawText($"Bmx Handlebar Angle: {firstBmx.HandleBarsAngle}", 20, 120, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
                canvas.DrawText($"Bearing to target: {firstBmx.Position.BearingTo(firstBmx.TargetPoint)}", 20, 140, new SKPaint() { Color = SKColors.Black, TextSize = 15, IsAntialias = true });
            }

            canvas.DrawText($"{gameState.GameSpeed} Speed", 1600, 50, new SKPaint() { Color = SKColors.Black, TextSize = 50, IsAntialias = true });

            if (gameState.Paused)
            {
                canvas.DrawText("PAUSED", 1600, 100, new SKPaint() { Color = SKColors.Red, TextSize = 50, IsAntialias = true });
            }

            foreach (var trackSegment in gameState.TrackSegments)
            {
                var colour = GetColourForTrackType(trackSegment.Type);
                if (trackSegment.Position == firstBmx?.TargetPoint) colour = SKColors.Blue;

                canvas.DrawCircle(trackSegment.Position.X, trackSegment.Position.Y, 5, new SKPaint() { Color = colour, Style = SKPaintStyle.Fill, IsAntialias = true });
            }

            foreach(var bmx in gameState.Bmxes)
            {
                BmxRenderer.Render(canvas, bmx);
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
