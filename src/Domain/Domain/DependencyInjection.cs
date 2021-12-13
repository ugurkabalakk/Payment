using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            return services;
        }
    }
}