using BMX.Models;
using BMX.Renderers.Interfaces;
using SkiaSharp;

namespace BMX.Renderers
{
    internal class MenuLayerRenderer : ILayerRenderer
    {
        public int ZLevel() => 99;

        public MenuLayerRenderer()
        {

        }

        public void Render(SKCanvas canvas, ApplicationState applicationState)
        {
            applicationState.UIState.Menus.ForEach(menu => menu.Controller)
        }
    }
}
