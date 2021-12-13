using Infrastructure.Persistence.DB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDatabase, Database>();

            services.AddSingleton(serviceProvider =>
            {
                var mongoSettings = serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value;

                var client = new MongoClient(mongoSettings.ConnectionString);

                var database = client.GetDatabase(mongoSettings.DatabaseName);

                return database;
            });

            return services;
        }
    }
}