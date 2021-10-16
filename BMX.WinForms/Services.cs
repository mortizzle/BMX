using Microsoft.Extensions.DependencyInjection;

namespace BMX.WinForms
{
    public static class Services
    {
        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<GameForm>();

            BMX.Services.ConfigureServices(services);
        }
    }
}
