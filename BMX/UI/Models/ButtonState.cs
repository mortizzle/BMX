using BMX.UI.Interfaces;

namespace BMX.UI.Models
{
    internal class ButtonState
    {
        IButtonController Controller {  get; set; }
        int XPos { get; set; }
        int YPos { get; set; }
    }
}
