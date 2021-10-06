using BMX.Renderers.Interfaces;
using BMX.UI;
using BMX.UI.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BMX.Renderers
{
    internal static class UIRegister
    {
        internal static void RegisterImplementations(ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IMenuFactory, MenuFactory>();
        }
    }
}
