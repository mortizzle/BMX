using System.Collections.Immutable;

namespace BMX.UI.Models
{
    public record UIState
    {
        public ImmutableList<MenuState> Menus { get; set; }
    }
}
