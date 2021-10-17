using BMX.Engine.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BMX.Actions
{
    internal static class ActionRegister
    {
        internal static void RegisterActions(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IAction, NewGameAction>();
        }
    }
}
