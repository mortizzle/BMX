using BMX.UI.Interfaces;
using System.Collections.Immutable;

namespace BMX.UI.Models
{
    internal class MenuState
    {
        IMenuController Controller { get; set; }
        ImmutableList<ButtonState> Buttons { get; set; }
        int XPos { get; set;  }
        int YPos { get; set; }
    }
}
