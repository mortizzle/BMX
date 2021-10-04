using SkiaSharp;

namespace BMX.Renderers.Interfaces
{
    internal interface ILayerRenderer
    {
        int ZLevel();
        void Render(SKCanvas canvas, GameState gameState);
    }
}
