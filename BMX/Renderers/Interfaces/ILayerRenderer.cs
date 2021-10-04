using SkiaSharp;

namespace BMX.Renderers.Interfaces
{
    internal interface ILayerRenderer
    {
        int GetHeight();
        void Render(SKCanvas canvas);
    }
}
