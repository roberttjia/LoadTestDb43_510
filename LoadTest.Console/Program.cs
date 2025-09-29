using LoadTest.Console.Services;
using LoadTest.Data;
using LoadTest.Data.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LoadTest.Console
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();
                
                var logger = host.Services.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("Starting LoadTest Console Application");
                logger.LogInformation("Database: LoadTestDb43_510 with 43 tables and 510+ columns");

                var loadTestService = host.Services.GetRequiredService<LoadTestService>();
                await loadTestService.RunLoadTestAsync();

                logger.LogInformation("LoadTest completed successfully!");
                return 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Application failed: {ex.Message}");
                System.Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return 1;
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false)
                          .AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    // Add database
                    services.AddLoadTestDatabase(context.Configuration);
                    
                    // Add services
                    services.AddScoped<LoadTestService>();
                    services.AddScoped<DataGeneratorService>();
                    services.AddScoped<EntityTestService>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                });
    }
}