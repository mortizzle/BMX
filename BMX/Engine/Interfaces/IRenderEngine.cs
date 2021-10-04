using SkiaSharp.Views.Desktop;

namespace BMX.Engine.Interfaces
{
    internal interface IRenderEngine
    {
        void Render(SKPaintSurfaceEventArgs e, GameState gameState);
    }
}