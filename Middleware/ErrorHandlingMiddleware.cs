using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text.Json;
using VaccinationCard.Api.Application.Notifications;
using System;

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

                // Verificar o tipo da exceção para retornar uma mensagem apropriada
                if (ex is ApplicationException appEx)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    var response = new { message = appEx.Message };
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var response = new ErrorNotification
                    {
                        StatusCode = httpContext.Response.StatusCode.ToString(),
                        Message = "An unexpected error occurred. Please try again later.",
                        Details = ex.StackTrace.ToString()
                    };

                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var json = JsonSerializer.Serialize(response, options);
                    await httpContext.Response.WriteAsync(json);
                }
            }
        }
    }
}
