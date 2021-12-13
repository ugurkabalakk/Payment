using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Infrastructure.Exceptions;
using Infrastructure.Loggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace API.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            var consoleLogger = app.ApplicationServices.GetRequiredService<IConsoleLogger>();

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async handler =>
                {
                    var ehf = handler.Features.Get<IExceptionHandlerFeature>();

                    if (ehf?.Error != null)
                    {
                        var statusCode = HttpStatusCode.InternalServerError;
                        var exceptionCode = ExceptionCodes.DefaultExceptionCode;

                        switch (ehf.Error)
                        {
                            case KeyNotFoundException _:
                                statusCode = HttpStatusCode.NotFound;
                                break;
                            case InvalidRequestException invalidRequestException:
                                exceptionCode = invalidRequestException.ExceptionCode;
                                statusCode = HttpStatusCode.BadRequest;
                                break;
                            case ExampleCustomBusinessException exampleCustomBusinessException:
                                statusCode = HttpStatusCode.Forbidden;
                                break;
                            case BusinessException businessException:
                                exceptionCode = businessException.ExceptionCode;
                                statusCode = HttpStatusCode.Conflict;
                                break;
                            // INFO https://stackoverflow.com/a/65989456
                            case TaskCanceledException taskCanceledException:
                                if (taskCanceledException.InnerException is TimeoutException)
                                    statusCode = HttpStatusCode.RequestTimeout;
                                break;
                            case TimeoutException _:
                                statusCode = HttpStatusCode.RequestTimeout;
                                break;
                        }

                        await consoleLogger.LogError(ehf.Error.Message, ehf.Error);

                        handler.Response.Clear();

                        handler.Response.StatusCode = (int)statusCode;
                        handler.Response.ContentType = @"application/json; charset=utf-8";

                        var error = JsonConvert.SerializeObject(new
                        {
                            ErrorMessage = ehf.Error.Message,
                            ExceptionCode = exceptionCode
                        });

                        await handler.Response.WriteAsync(error);
                    }
                });
            });
        }
    }
}