using BMX.Engine.Interfaces;
using BMX.Renderers.Interfaces;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Collections.Generic;
using System.Linq;

namespace BMX.Engine
{
    internal class RenderEngine : IRenderEngine
    {
        private readonly IEnumerable<ILayerRenderer> _layerRenderers;

        public RenderEngine(IEnumerable<ILayerRenderer> layerRenderers)
        {
            _layerRenderers = layerRenderers;
        }

        public void Render(SKPaintSurfaceEventArgs e, GameState gameState)
        {
            foreach(var layerRenderer in _layerRenderers.OrderBy(renderer => renderer.ZLevel()))
            {
                layerRenderer.Render(e.Surface.Canvas, gameState);
            }
            
        }
    }
}
