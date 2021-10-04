using BMX.UI.Interfaces;

namespace BMX.UI.Models
{
    internal class ButtonState
    {
        public IButtonController Controller {  get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
    }
}
