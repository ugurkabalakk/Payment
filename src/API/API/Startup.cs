using API.Extensions;
using API.Extensions.InjectorExtensions;
using API.HealthChecks;
using API.Middlewares;
using Application;
using HealthChecks.UI.Client;
using Infrastructure;
using Infrastructure.Loggers;
using Infrastructure.Persistence.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterControllers();

            services.AddHealthChecks()
                .AddCheck<ReadinessHealthCheck>("readiness-check", HealthStatus.Unhealthy, new[] { "readiness" });

            services.AddSingleton<IConsoleLogger, ConsoleLogger>();

            services.Configure<MongoSettings>(_configuration.GetSection("MongoSettings"));

            services.AddOptions();

            services.AddApplication();

            services.AddInfrastructure();

            // TODO: move this to somewhere else and decide convention rules with team.


            services.AddTransient<CorrelationIdMiddleware>();

            services.AddTransient<RequestResponseLoggingMiddleware>();

            services.RegisterSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseCorrelationId();
            app.UseHttpsRedirection();
            app.UseRequestResponseLogger();
            app.UseGlobalExceptionHandler();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/ready", new HealthCheckOptions
                {
                    Predicate = check => check.Tags.Contains("readiness"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    /* TODO: it's a workaround solution because we actually don't want seperate v0.0 as version but we want to support legacy services too
                             to not effect our clients. */
                    options.SwaggerEndpoint("/swagger/v0.0/swagger.json", "v0.0");
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                });
        }
    }
}