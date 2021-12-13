using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;

namespace Infrastructure.Persistence.DB
{
    public class Database : IDatabase
    {
        private readonly IMongoDatabase _mongoDatabase;

        public Database(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            Configure();
        }

        public bool IsAvailable()
        {
            var ping = _mongoDatabase.RunCommandAsync((Command<BsonDocument>)"{ping:1}");

            // analyze that time with k8s readiness probe habbits
            if (!ping.Wait(1000)) return false;

            if (ping.Result.Contains("ok") && (ping.Result["ok"].IsDouble && (int)ping.Result["ok"].AsDouble == 1 ||
                                               ping.Result["ok"].IsInt32 && ping.Result["ok"].AsInt32 == 1))
                return _mongoDatabase.Client.Cluster.Description.State == ClusterState.Connected;

            return false;
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _mongoDatabase.GetCollection<T>(collectionName);
        }

        private void Configure()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfNullConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };

            ConventionRegistry.Register("ugur-mongo-convention", pack, t => true);
        }
    }
}