using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text.Json;
using VaccinationCard.Api.Application.Notifications;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Options;

namespace VaccinationCard.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                httpContext.Response.ContentType = "application/json";

                // Verificar o tipo da exceção 
                if (ex is ErrorNotification errorNotification)
                {
                    httpContext.Response.StatusCode = errorNotification.StatusCode;
                    var response = new
                    {
                        statusCode = errorNotification.StatusCode,
                        errorMessage = errorNotification.ErrorMessage,
                        details = errorNotification.Details
                    };
                    
                    var json = JsonSerializer.Serialize(response);
                    await httpContext.Response.WriteAsync(json);
                }
                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var response = new ErrorNotification
                    (
                        httpContext.Response.StatusCode,
                        "An unexpected error occurred. Please try again later.",
                        ex.StackTrace.ToString()
                    );

                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var json = JsonSerializer.Serialize(response, options);
                    await httpContext.Response.WriteAsync(json);
                }
            }
        }
    }
}
