﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Pow.WebApi.Extensions
{
    public static class AuthManager
    {
        public static void AddCustomAuthConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:44316/";
                    options.Audience = "PowWebApi";
                    options.RequireHttpsMetadata = false;
                });

        }


    }
}
