using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Pow.WebApi.Extensions;
using Serilog;

namespace Pow.WebApi
{
    public class Program
    {

        public static void Main(string[] args)
        {
            LoggerManager.RunSerilog();

            try
            {
                Log.Information("Starting host...");

                CreateHostBuilder(args)
               .Build()
               .SetupLogger()
               .MigrateDatabase()
               .Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
