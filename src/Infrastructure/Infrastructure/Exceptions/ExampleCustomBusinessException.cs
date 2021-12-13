using System;
using System.Runtime.Serialization;

namespace Infrastructure.Exceptions
{
    [Serializable]
    public class ExampleCustomBusinessException : BusinessException
    {
        public ExampleCustomBusinessException(string code)
            : base("Example custom exception message", ExceptionCodes.ExampleCustomExceptionCode)
        {
        }

        protected ExampleCustomBusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}