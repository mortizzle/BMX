using BMX.Renderers.Interfaces;
using SkiaSharp;
using System;

namespace BMX.Renderers
{
    internal class TerrainRenderer : ILayerRenderer
    {
        public int ZLevel() => 0;

        public void Render(SKCanvas canvas, GameState gameState)
        {
            canvas.Clear(SKColors.LightGreen);
        }
    }
}
