using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Persistence.DB;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace API.HealthChecks
{
    public class ReadinessHealthCheck : IHealthCheck
    {
        private readonly IDatabase _database;

        public ReadinessHealthCheck(IDatabase database)
        {
            _database = database;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy());

            // // TODO: Readiness 
            // var dbIsAvailable = _database.IsAvailable();

            // if (dbIsAvailable) return Task.FromResult(HealthCheckResult.Healthy());

            // return Task.FromResult(HealthCheckResult.Unhealthy());
        }
    }
}