using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Domain
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = ObjectId.GenerateNewId();
            InsertedDate = DateTime.UtcNow;
        }

        [BsonId] [BsonElement(Order = 0)] public ObjectId Id { get; protected set; }
        public DateTime InsertedDate { get; protected set; }
    }
}