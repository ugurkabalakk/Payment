using System.Collections.Generic;

namespace Application.Common.Responses.SampleSwaggerResponses
{
    public class ValidationResultResponse
    {
        public string Message { get; set; }
        public List<ErrorsObj> Errors { get; set; }
    }

    public class ErrorsObj
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}