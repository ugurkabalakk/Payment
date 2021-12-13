using MongoDB.Driver;

namespace Infrastructure.Persistence.DB
{
    public interface IDatabase
    {
        bool IsAvailable();
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}