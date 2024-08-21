using System.Net;
using System.Text.Json;
using MovieWebAPI.Exceptions;
using NuGet.Configuration;

namespace MovieWebAPI.Middleware
{
    public class CustomExceptionHandler
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        
        public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            string message;
            switch (ex)
            {
                case NullEntity:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;

                case NotNullEntity:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                case NullList:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;

                default:
                    if (ex.Message.Contains("Invalid Token"))
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        message = ex.Message;
                        break;
                    }
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = "We're sorry, we have an internal server error!";
                    break;
            }
            _logger.LogError(ex.Message, ex.StackTrace);
            var result = JsonSerializer.Serialize(new { errorMessage = message });
            await context.Response.WriteAsync(result);
        }
    }
}
