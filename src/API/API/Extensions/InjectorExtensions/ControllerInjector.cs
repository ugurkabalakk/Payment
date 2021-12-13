using System.Text.Json;
using API.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.InjectorExtensions
{
    public static class ControllerInjector
    {
        public static void RegisterControllers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers(setup =>
            {
                setup.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions()));

                setup.ReturnHttpNotAcceptable = true;

                setup.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
                setup.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                setup.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));

                setup.Filters.Add<ValidationFilterAttribute>();
            }).AddFluentValidation();

            serviceCollection.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}