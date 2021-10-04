using BMX.Models;
using BMX.Renderers.Interfaces;
using SkiaSharp;

namespace BMX.Renderers
{
    internal class MenuRenderer : ILayerRenderer
    {
        public int ZLevel() => 99;

        public MenuRenderer()
        {

        }

        public void Render(SKCanvas canvas, ApplicationState applicationState)
        {
            
        }
    }
}
