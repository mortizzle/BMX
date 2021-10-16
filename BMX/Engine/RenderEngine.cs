using BMX.Engine.Interfaces;
using BMX.Models;
using BMX.Renderers.Interfaces;
using SkiaSharp;
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

        public void Render(SKCanvas canvas, ApplicationState applicationState)
        {
            foreach(var layerRenderer in _layerRenderers.OrderBy(renderer => renderer.ZLevel()))
            {
                layerRenderer.Render(canvas, applicationState);
            }
            
        }
    }
}
