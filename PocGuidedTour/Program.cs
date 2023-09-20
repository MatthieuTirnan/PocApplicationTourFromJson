using GTour;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PocGuidedTour;
using PocGuidedTour.Options;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.UseGTour();
        
        builder.Services.AddSingleton<AppSettingsOptions>();
        builder.Configuration.Bind(AppSettingsOptions.Tour1, AppSettingsOptions.Instance);
        
        await builder.Build().RunAsync();
    }
}

