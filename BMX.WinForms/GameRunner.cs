using Microsoft.Extensions.DependencyInjection;

namespace BMX.WinForms
{
    internal static class GameRunner
    {
        internal static void Run(Action<Form> runGameForm)
        {
            var serviceCollection = new ServiceCollection();
            Services.ConfigureServices(serviceCollection);

            using (ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var gameForm = serviceProvider.GetRequiredService<GameForm>();
                runGameForm(gameForm);
            }
        }
    }
}
