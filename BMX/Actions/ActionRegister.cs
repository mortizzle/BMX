using BMX.Engine.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMX.Actions
{
    internal static class ActionRegister
    {
        internal static void RegisterActions(ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IAction, NewGameAction>();
        }
    }
}
