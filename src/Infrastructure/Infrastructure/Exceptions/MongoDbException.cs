using System;
using System.Runtime.Serialization;

namespace Infrastructure.Exceptions
{
    [Serializable]
    public class MongoDbException : Exception
    {
        public MongoDbException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MongoDbException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}