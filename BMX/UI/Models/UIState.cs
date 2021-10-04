using System.Collections.Immutable;

namespace BMX.UI.Models
{
    internal record UIState
    {
        public ImmutableList<MenuState> Menus { get; set; }
    }
}
