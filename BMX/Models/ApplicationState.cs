using BMX.UI.Models;

namespace BMX.Models
{
    internal record ApplicationState
    {
        public GameState GameState { get; set; }
        public UIState UIState { get; set; }
    }
}
