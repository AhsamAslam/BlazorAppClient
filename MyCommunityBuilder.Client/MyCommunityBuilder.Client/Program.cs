using Blazored.LocalStorage;
using BlazorStyled;
using ICSharpCode.Decompiler.Util;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyCommunityBuilder.Client.Helpers;
using MyCommunityBuilder.Client.Localization;
using MyCommunityBuilder.Client.Services;
using MyCommunityBuilder.Client.Shared;
using MyCommunityBuilder.Components;
using MyCommunityBuilder.Shared;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace MyCommunityBuilder.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            var url = builder.Configuration.GetValue<string>("ServerlessBaseURI");
            //string serverlessBaseURI = builder.Configuration["ServerlessBaseURI"];
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5001/api/") });
            //builder.Services.AddSingleton<LocalizationDropDown>();
            builder.Services.AddHttpClient<BusinessClient>(client => client.BaseAddress = new Uri(url + "api/"));
            builder.Services.AddHttpClient<EventClient>(client => client.BaseAddress = new Uri(url + "api/"));
            builder.Services.AddHttpClient<FanClient>(client => client.BaseAddress = new Uri(url + "api/"));
            builder.Services.AddHttpClient<LanguageClient>(client => client.BaseAddress = new Uri(url + "api/Localization/"));
            builder.Services.AddHttpClient<LocalizationClient>(client => client.BaseAddress = new Uri(url + "api/"));
            builder.Services.AddHttpClient<GenericLocalizationClient>(client => client.BaseAddress = new Uri(url + "api/Localization/"));
            builder.Services.AddHttpClient<SiteClient>(client => client.BaseAddress = new Uri(url + "api/"));
            builder.Services.AddHttpClient<HeaderClient>(client => client.BaseAddress = new Uri(url + "api/"));
            builder.Services.AddHttpClient<CSSClient>(client => client.BaseAddress = new Uri(url + "api/"));
            //builder.Services.AddHttpClient<AccountService>(client => client.BaseAddress = new Uri("http://localhost:5000"));
            builder.Services.AddFileReaderService();
            builder.Services.AddBlazorStyled();
            builder.Services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTMwOTAwQDMxMzkyZTMzMmUzMEVreTlQT2E5c0E0dkU2SE9zQlNrbllTc0I3cC8ybGFUcFFpbjZVcWZvcnM9");
            Console.WriteLine("Ahsam" + url);

            builder.Services.AddHttpClient("MyCommunityBuilder.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
              .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyCommunityBuilder.ServerAPI"));

            builder.Services.AddScoped<HttpService>();
            builder.Services.AddScoped<AccountService>();

            builder.Services.AddApiAuthorization()
                    .AddAccountClaimsPrincipalFactory<CustomUserFactory>();
            builder.Services.AddLogging(options =>
            {
                options.ClearProviders();
                options.AddProvider(new ConsoleLoggerProvider(options.Services));
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddLocalization();
            //builder.Services.AddBlazoredLocalStorage();
            //await builder.Build().RunAsync();
            var host = builder.Build();
            await host.SetDefaultCulture();
            await host.RunAsync();
        }
    }
}
