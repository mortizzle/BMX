using BMX.Models;
using SkiaSharp;

namespace BMX.Engine.Interfaces
{
    public interface IRenderEngine
    {
        void Render(SKCanvas canvas, ApplicationState applicationState);
    }
}