using Microsoft.Extensions.DependencyInjection;
using BMX.Engine.Interfaces;
using BMX.Renderers;
using BMX.Renderers.Interfaces;

namespace BMX.Engine
{
    internal static class Services
    {
        internal static ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services
             .AddScoped<GameForm>()
             .AddScoped<IInputHandler, InputHandler>()
             .AddScoped<IRenderEngine, RenderEngine>();
             
            LayerRegister.RegisterImplementations(services);

            return services;
        }
    }
}
