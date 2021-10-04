using BMX.Models;
using BMX.Renderers.Interfaces;
using SkiaSharp;

namespace BMX.Renderers
{
    internal class TerrainLayerRenderer : ILayerRenderer
    {
        public int ZLevel() => 0;

        public void Render(SKCanvas canvas, ApplicationState applicationState)
        {
            canvas.Clear(SKColors.LightGreen);
        }
    }
}
