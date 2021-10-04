using BMX.Renderers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BMX.Renderers
{
    internal static class LayerRegister
    {
        internal static void RegisterImplementations(ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ILayerRenderer, TerrainRenderer>();
        }
    }
}
