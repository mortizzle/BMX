using Microsoft.Extensions.DependencyInjection;
using BMX.Engine.Interfaces;
using BMX.Renderers;
using BMX.Actions;
using BMX.Engine;

namespace BMX
{
    public static class Services
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<IInputHandler, InputHandler>()
                .AddScoped<IRenderEngine, RenderEngine>()
                .AddScoped<IGameEngine, GameEngine>();
             
            LayerRegister.RegisterImplementations(services);
        }
    }
}
