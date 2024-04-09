using DotNetBankingAppClient.Helpers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace DotNetBankingAppClient
{
    public class Program
    {
        private static void ConfigureBuilder(ref WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
        }

        private static void AddScopes(ref WebAssemblyHostBuilder builder)
        {
            string apiUri = "http://localhost:5000/";
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri(apiUri) };

            builder.Services.AddScoped(sp => httpClient);
            builder.Services.AddScoped<IBrowserStorage, BrowserStorage>();
            builder.Services.AddScoped<IWindowHelper, WindowHelper>();
            ApiServices.Initialize(httpClient);
        }


        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            ConfigureBuilder(ref builder);
            AddScopes(ref builder);

            await builder.Build().RunAsync();
        }
    }
}