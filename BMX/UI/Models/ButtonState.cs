using System;
using BMX.Models;
using SkiaSharp;

namespace BMX.UI.Models
{
    public class ButtonState
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Action<SKCanvas> Render { get; set; }
        public Func<ApplicationState, ApplicationState> OnClick { get; set; } = (ApplicationState applicationState) => applicationState;
    }
}
