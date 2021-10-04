using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BMX.Engine
{
    internal static class GameRunner
    {
        internal static void Run(Action<Form> runGameForm)
        {
            using (ServiceProvider serviceProvider = Services.ConfigureServices().BuildServiceProvider())
            {
                var gameForm = serviceProvider.GetRequiredService<GameForm>();
                runGameForm(gameForm);
            }
        }
    }
}
