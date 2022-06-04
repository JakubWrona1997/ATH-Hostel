using ATH_Hostel.Infrastructure;
using ATH_Hostel.Infrastructure.FakeData;
using ATH_Hostel.Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATH_Hostel
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {               
                var loggerFactor = scope.ServiceProvider.GetService<ILoggerFactory>();
                try
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<HostelDBContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await RolesSeeder.SeedRolesAsync(userManager, roleManager);
                    DataGenerator.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactor.CreateLogger<Program>();
                    logger.LogError(ex, "Something went wrong when seeding database");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
