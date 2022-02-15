using MyCommunityBuilder.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace MyCommunityBuilder.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build()
                .MigrateDatabase<ApplicationDbContext>((context, services) =>
                {

                });
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                ApplicationDbRawQueryExe.ExecuteInitRaw(context);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
					webBuilder.UseStartup<Startup>();
                    //webBuilder.ConfigureKestrel(serverOptions =>
                    //{
                      //  serverOptions.Listen(IPAddress.Any, Convert.ToInt32(Environment.GetEnvironmentVariable("PORT")));
                    //}).UseStartup<Startup>();
                });
    }
}
