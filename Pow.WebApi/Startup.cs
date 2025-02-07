using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pow.Application.Services;
using Pow.Application.Services.Interfaces;
using Pow.WebApi.Extensions;
using Pow.WebApi.Middleware;

namespace Pow.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomDapperConfiguration(Configuration);

            services.AddControllers();

            services.AddCustomCorsConfiguration();

            services.AddCustomAuthConfiguration();

            services.AddInfrastructure();

            services.AddValidators();

            services.AddAutoMapper();

            services.AddSingleton<IBLLMessageService, BLLMessageService>();

            services.AddSingleton<IBLLMarkService, BLLMarkService>();

            services.AddSingleton<IBLLAttachmentService, BLLAttachmentService>();

            services.AddSingleton<IBLLService, BLLService>();

            services.AddSingleton<IMarksOnMapService, MarksOnMapServices>();

            DapperExtensions.AddSqlGuidHandler();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
