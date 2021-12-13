using System;
using System.Runtime.Serialization;

namespace Infrastructure.Exceptions
{
    [Serializable]
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException()
        {
        }

        public InvalidRequestException(string message)
            : base(message)
        {
        }

        public InvalidRequestException(string message, string exceptionCode)
            : base(message)
        {
            ExceptionCode = exceptionCode;
        }

        public InvalidRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string ExceptionCode { get; set; }
    }
}