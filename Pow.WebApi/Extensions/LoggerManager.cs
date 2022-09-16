﻿using Microsoft.Extensions.Hosting;
using Serilog.Events;
using Serilog;
using System.Diagnostics;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Pow.WebApi.Extensions
{
    public static class LoggerManager
    {
        public static IHost SetupLogger(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    // todo add need scopes
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "An error occurred while app Initialization");
                }
            }

            return host;
        }


        public static void RunSerilog()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File("Pow_Api_WebLog.txt", rollingInterval:
                    RollingInterval.Day)
                .CreateLogger();
        }
    }
}
