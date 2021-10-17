using BMX;
using BMX.Blazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddTransient<ITimer, BlazorTimer>();

Services.ConfigureServices(builder.Services);
await builder.Build().RunAsync();
