using System;
using System.IO;
using System.Reflection;
using API.Settings.Swagger;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Extensions.InjectorExtensions
{
    public static class SwaggerInjector
    {
        public static void RegisterSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VV";
                options.SubstituteApiVersionInUrl = true;
            });

            serviceCollection.AddApiVersioning(options =>
            {
                options.Conventions.Add(new VersionByNamespaceConvention());
                options.ReportApiVersions = true;
            });

            serviceCollection.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            serviceCollection.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.EnableAnnotations();
                options.OperationFilter<SwaggerDefaultValues>();

                options.CustomSchemaIds(x => x.ToString());
            });
        }
    }
}