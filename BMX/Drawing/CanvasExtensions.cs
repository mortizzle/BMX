using SkiaSharp;
using System;

namespace BMX.Drawing
{
    internal static class CanvasExtensions
    {
        public static void At(this SKCanvas canvas, int X, int Y, Action<SKCanvas> action)
        {
            canvas.Save();
            canvas.Translate(X, Y);
            action(canvas);
            canvas.Restore();   
        }
    }
}
