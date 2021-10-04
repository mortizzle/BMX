using Microsoft.Extensions.DependencyInjection;
using BMX.Engine.Interfaces;
using BMX.Renderers;

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
                .AddScoped<IRenderEngine, RenderEngine>()
                .AddScoped<IGameEngine, GameEngine>();
             
            LayerRegister.RegisterImplementations(services);

            return services;
        }
    }
}
