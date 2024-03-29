﻿using BMX.Models;
using SkiaSharp;

namespace BMX.Renderers.Interfaces
{
    internal interface ILayerRenderer
    {
        int ZLevel();
        void Render(SKCanvas canvas, ApplicationState applicationState);
    }
}
