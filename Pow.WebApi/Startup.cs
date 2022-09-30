using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pow.Infrastructure.Repositories;
using Pow.Infrastructure.Repositories.Interfaces;
using Pow.WebApi.Extensions;
using Pow.WebApi.Middleware;

namespace Pow.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomDapperConfiguration(this.Configuration);

            services.AddControllers();

            services.AddCustomCorsConfiguration();

            services.AddCustomAuthConfiguration();

            services.AddInfrastructure();

            services.AddValidators();

            services.AddSingleton<IMessageRepository, MessageRepository>();

            services.AddSingleton<IMarkRepository, MarkRepository>();

            services.AddSingleton<IAttachmentRepository, AttachmentRepository>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}