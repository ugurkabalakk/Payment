using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Loggers
{
    public class ConsoleLogger : IConsoleLogger
    {
        public async Task Log(LogLevel logLevel, string message, Exception exception, string responseBody,
            string requestBody,
            HttpMethod httpMethod, HttpStatusCode httpStatusCode, long? duration, string hostName, string url,
            string origin)
        {
            await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(new
            {
                CorrelationId = Trace.CorrelationManager.ActivityId,
                DateTime = DateTime.Now,
                LogLevel = logLevel.ToString(),
                Message = message,
                Exception = exception?.ToString(),
                ResponseBody = responseBody,
                RequestBody = requestBody,
                HttpMethod = httpMethod?.Method,
                HttpStatusCode = (int)httpStatusCode,
                Duration = duration,
                HostName = hostName,
                Url = url,
                Origin = origin
            }));
        }

        public async Task LogTrace(string message, Exception exception = null, string responseBody = null,
            string requestBody = null,
            HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
            string hostName = null,
            string url = null, string origin = null)
        {
            await Log(LogLevel.Trace, message, exception, responseBody, requestBody, httpMethod,
                httpStatusCode.GetValueOrDefault(), duration, hostName, url, origin);
        }

        public async Task LogDebug(string message, Exception exception = null, string responseBody = null,
            string requestBody = null,
            HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
            string hostName = null,
            string url = null, string origin = null)
        {
            await Log(LogLevel.Debug, message, exception, responseBody, requestBody, httpMethod,
                httpStatusCode.GetValueOrDefault(), duration, hostName, url, origin);
        }

        public async Task LogInformation(string message, Exception exception = null, string responseBody = null,
            string requestBody = null,
            HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
            string hostName = null,
            string url = null, string origin = null)
        {
            await Log(LogLevel.Information, message, exception, responseBody, requestBody, httpMethod,
                httpStatusCode.GetValueOrDefault(), duration, hostName, url, origin);
        }

        public async Task LogWarning(string message, Exception exception = null, string responseBody = null,
            string requestBody = null,
            HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
            string hostName = null,
            string url = null, string origin = null)
        {
            await Log(LogLevel.Warning, message, exception, responseBody, requestBody, httpMethod,
                httpStatusCode.GetValueOrDefault(), duration, hostName, url, origin);
        }

        public async Task LogError(string message, Exception exception = null, string responseBody = null,
            string requestBody = null,
            HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
            string hostName = null,
            string url = null, string origin = null)
        {
            await Log(LogLevel.Error, message, exception, responseBody, requestBody, httpMethod,
                httpStatusCode.GetValueOrDefault(), duration, hostName, url, origin);
        }

        public async Task LogCritical(string message, Exception exception = null, string responseBody = null,
            string requestBody = null,
            HttpMethod httpMethod = null, HttpStatusCode? httpStatusCode = null, long? duration = null,
            string hostName = null,
            string url = null, string origin = null)
        {
            await Log(LogLevel.Critical, message, exception, responseBody, requestBody, httpMethod,
                httpStatusCode.GetValueOrDefault(), duration, hostName, url, origin);
        }
    }
}