using BMX.Renderers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BMX.Renderers
{
    internal static class LayerRegister
    {
        internal static void RegisterImplementations(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ILayerRenderer, TerrainLayerRenderer>()
                .AddScoped<ILayerRenderer, MenuLayerRenderer>();
        }
    }
}
