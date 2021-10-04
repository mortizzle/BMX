using System.Collections.Immutable;

namespace BMX.UI.Models
{
    internal record UIState
    {
        ImmutableList<MenuState> Menus { get; set; }
    }
}
