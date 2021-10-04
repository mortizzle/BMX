using BMX.Renderers.Interfaces;
using SkiaSharp;
using System;

namespace BMX.Renderers
{
    internal class TerrainRenderer : ILayerRenderer
    {
        public int GetHeight() => 0;

        public void Render(SKCanvas canvas)
        {
            canvas.Clear(SKColors.LightGreen);
        }
    }
}
