using System.Collections.Immutable;

namespace BMX.UI.Models
{
    public class MenuState
    {
        public ImmutableList<ButtonState> Buttons { get; set; }
        public int XPos { get; set;  }
        public int YPos { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
