using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Loggers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace API.Middlewares
{
    public class RequestResponseLoggingMiddleware : IMiddleware
    {
        private readonly IConsoleLogger _consoleLogger;

        public RequestResponseLoggingMiddleware(IConsoleLogger consoleLogger)
        {
            _consoleLogger = consoleLogger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var requestUrl = context.Request.GetDisplayUrl();

            if (!IsAppUrl(requestUrl))
                await next(context);
            if (!IsAppUrl(requestUrl))
                return;

            var method = context.Request.Method;
            var request = string.Empty;
            var response = string.Empty;

            if (ShouldApplyRequestLogging(method))
                using (var bodyReader = new StreamReader(context.Request.Body))
                {
                    request = await bodyReader.ReadToEndAsync();
                    context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(request));
                }

            context.Request.Headers.TryGetValue("Origin", out var origin);

            await _consoleLogger.LogInformation("API OnActionExecuting", null, response, request,
                new HttpMethod(method), HttpStatusCode.Processing, null, context.Request.Host.Value, requestUrl
                , origin);

            var timer = new Stopwatch();
            timer.Start();

            using (var buffer = new MemoryStream())
            {
                var stream = context.Response.Body;
                context.Response.Body = buffer;

                await next(context);
                timer.Stop();

                buffer.Seek(0, SeekOrigin.Begin);
                using (var bufferReader = new StreamReader(buffer))
                {
                    response = await bufferReader.ReadToEndAsync();
                    buffer.Seek(0, SeekOrigin.Begin);
                    await buffer.CopyToAsync(stream);
                }
            }

            var durationInMilliseconds = timer.ElapsedMilliseconds;

            await _consoleLogger.LogInformation("API OnActionExecuted", null, response, request,
                new HttpMethod(method), (HttpStatusCode)context.Response.StatusCode, durationInMilliseconds,
                context.Request.Host.Value, requestUrl);
        }

        private static bool IsAppUrl(string requestUrl)
        {
            requestUrl = requestUrl.ToLower();
            return !requestUrl.Contains("/health") && !requestUrl.Contains(".ico") && !requestUrl.Contains("swagger");
        }

        private static bool ShouldApplyRequestLogging(string method)
        {
            if (method is "PUT" or "POST") return true;

            return false;
        }
    }
}