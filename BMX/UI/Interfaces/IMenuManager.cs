using System.Collections.Generic;

namespace BMX.UI.Interfaces
{
    internal interface IMenuManager
    {
        IEnumerable<IMenu> GetVisibleMenus();
    }
}
