using System.Reflection;
using Application.Common.CommandQueryWrappers;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // TODO: disabled all validations for now, we should be able them after implementation completed
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(typeof(IRequestHandlerWrapper<,>).Assembly);

            services.AddDomain();

            return services;
        }
    }
}