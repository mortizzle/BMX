using SkiaSharp;

namespace BMX.UI.Interfaces
{
    internal interface IMenuController
    {
        void Render(SKCanvas canvas);

        void HandleInput();
    }
}
