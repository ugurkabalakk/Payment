using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infrastructure.Domain;
using Infrastructure.Exceptions;
using Infrastructure.Persistence.DB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Repository
{
    public abstract class Repository<T> where T : Entity
    {
        private readonly string _collectionName;
        private readonly IDatabase _database;

        protected Repository(IDatabase database, string collectionName)
        {
            _database = database;
            _collectionName = collectionName;
        }

        private IMongoCollection<T> Collection => _database.GetCollection<T>(_collectionName);

        private static UpdateDefinitionBuilder<T> Update => Builders<T>.Update;

        public async Task InsertAsync(IClientSessionHandle sessionHandle, T entity)
        {
            try
            {
                await Collection.InsertOneAsync(sessionHandle, entity);
            }
            catch (MongoWriteException mongoWriteException)
            {
                var writeErrorCode = mongoWriteException.WriteError.Code;
                throw new MongoDbException($"ErrorCode:{writeErrorCode} Exception:{mongoWriteException.Message}",
                    mongoWriteException);
            }
            catch (MongoCommandException mongoCommandException)
            {
                var writeErrorCode = mongoCommandException.Code;
                throw new MongoDbException($"ErrorCode:{writeErrorCode} Exception:{mongoCommandException.Message}",
                    mongoCommandException);
            }
            catch (Exception ex)
            {
                throw new MongoDbException(ex.Message, ex);
            }
        }

        public async Task InsertAsync(T entity)
        {
            try
            {
                await Collection.InsertOneAsync(entity);
            }
            catch (MongoWriteException mongoWriteException)
            {
                var writeErrorCode = mongoWriteException.WriteError.Code;
                throw new MongoDbException($"ErrorCode:{writeErrorCode} Exception:{mongoWriteException.Message}",
                    mongoWriteException);
            }
            catch (MongoCommandException mongoCommandException)
            {
                var writeErrorCode = mongoCommandException.Code;
                throw new MongoDbException($"ErrorCode:{writeErrorCode} Exception:{mongoCommandException.Message}",
                    mongoCommandException);
            }
            catch (Exception ex)
            {
                throw new MongoDbException(ex.Message, ex);
            }
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filter)
        {
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> FindOneAsync(IClientSessionHandle sessionHandle, Expression<Func<T, bool>> filter)
        {
            return await Collection.Find(sessionHandle, filter).FirstOrDefaultAsync();
        }

        public async Task UpdateOneAsync<TField>(ObjectId documentId, Expression<Func<T, TField>> field, TField value)
        {
            await Collection.UpdateOneAsync(c => c.Id == documentId, Update.Set(field, value));
        }

        public async Task<bool> UpdateDocumentAsync(BsonObjectId documentId, T document)
        {
            var response = await Collection.ReplaceOneAsync(c => c.Id == documentId, document);
            return response.ModifiedCount == 1;
        }

        public async Task<bool> UpdateDocumentAsync(IClientSessionHandle sessionHandle, BsonObjectId documentId,
            T document)
        {
            var response = await Collection.ReplaceOneAsync(sessionHandle, c => c.Id == documentId, document);
            return response.ModifiedCount == 1;
        }
    }
}