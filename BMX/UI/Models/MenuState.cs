using BMX.UI.Interfaces;
using System.Collections.Immutable;

namespace BMX.UI.Models
{
    internal class MenuState
    {
        public IMenuController Controller { get; set; }
        public ImmutableList<ButtonState> Buttons { get; set; }
        public int XPos { get; set;  }
        public int YPos { get; set; }
    }
}
