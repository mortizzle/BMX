using SkiaSharp;
using System.Numerics;

namespace BMX
{
    internal static class BmxRenderer
    {
        private static readonly SKPaint WheelPaint = new SKPaint() { Color = SKColors.Black, Style = SKPaintStyle.Fill, IsAntialias = true };
        private static readonly SKPaint FramePaint = new SKPaint() { Color = SKColors.DarkRed, StrokeWidth = 2, IsAntialias = true };
        private static readonly SKPaint HandlebarPaint = new SKPaint() { Color = SKColors.Gray, StrokeWidth = 2, IsAntialias = true };
        private static readonly SKPaint RiderBodyPaint = new SKPaint() { Color = SKColors.Green, Style = SKPaintStyle.Fill, StrokeWidth = 3, IsAntialias = true };
        private static readonly SKPaint RiderHelmetPaint = new SKPaint() { Color = SKColors.Blue, Style = SKPaintStyle.Fill, IsAntialias = true };


        internal static void Render(SKCanvas canvas, Bmx bmx)
        {
            canvas.Save();
            canvas.RotateDegrees((float)bmx.FrameBearing, bmx.Position.X, bmx.Position.Y);

            var frontWheelCenter = Vector2.Add(bmx.Position, new Vector2(-10, 0));
            var backWheelCenter = Vector2.Add(bmx.Position, new Vector2(10, 0));
            var handlerBarsCenter = Vector2.Add(frontWheelCenter, new Vector2(3, 0));
            var riderCenter = Vector2.Add(bmx.Position, new Vector2(7,0));

            DrawWheel(canvas, frontWheelCenter);
            DrawWheel(canvas, backWheelCenter);
            DrawFrame(canvas, frontWheelCenter, backWheelCenter);
            var (rightHandlebarEnd, leftHandlebarEnd) = DrawHandleBars(canvas, handlerBarsCenter);
            DrawRider(canvas, riderCenter, rightHandlebarEnd, leftHandlebarEnd);

            canvas.Restore();
        }

        private static void DrawRider(SKCanvas canvas, Vector2 riderCenter, Vector2 rightHandlebarEnd, Vector2 leftHandlebarEnd)
        {
            // Draw Arms
            canvas.DrawLine(riderCenter.X, riderCenter.Y, rightHandlebarEnd.X, rightHandlebarEnd.Y, RiderBodyPaint);
            canvas.DrawLine(riderCenter.X, riderCenter.Y, leftHandlebarEnd.X, leftHandlebarEnd.Y, RiderBodyPaint);

            // Draw Body
            canvas.DrawCircle(riderCenter.X, riderCenter.Y, 5, RiderBodyPaint);

            // Draw Head
            canvas.DrawCircle(riderCenter.X-5, riderCenter.Y, 3, RiderHelmetPaint);
        }

        private static (Vector2 rightEnd, Vector2 leftEnd) DrawHandleBars(SKCanvas canvas, Vector2 frontWheelCenter)
        {
            var rightBendRightY = frontWheelCenter.Y - 10;
            var rightBendLeftY = frontWheelCenter.Y + 10;
            var rightEnd = new Vector2(frontWheelCenter.X + 5, rightBendRightY - 3);
            var leftEnd = new Vector2(frontWheelCenter.X + 5, rightBendLeftY + 3);

            canvas.DrawLine(frontWheelCenter.X, rightBendRightY, frontWheelCenter.X, rightBendLeftY, HandlebarPaint);
            canvas.DrawLine(frontWheelCenter.X, rightBendRightY, rightEnd.X, rightEnd.Y, HandlebarPaint);
            canvas.DrawLine(frontWheelCenter.X, rightBendLeftY, leftEnd.X, leftEnd.Y, HandlebarPaint);

            return (rightEnd, leftEnd);

        }

        private static void DrawFrame(SKCanvas canvas, Vector2 frontWheelCenter, Vector2 backWheelCenter)
        {
            canvas.DrawLine(frontWheelCenter.X, frontWheelCenter.Y, backWheelCenter.X, backWheelCenter.Y, FramePaint);
        }

        private static void DrawWheel(SKCanvas canvas, Vector2 position)
        {
            canvas.DrawOval(position.X, position.Y, 10, 3f, WheelPaint);
        }
    }
}
