using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Exceptions;

namespace WebApplication1.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
              await HandleExceptionAsync(httpContext, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            string message;
            switch (ex)
            {

                case EntityNotFoundException exe:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    message = "Entity was not found";
                    break;

                case ArgumentNullException exe:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                case OperationFailedException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest; 
                    message = ex.Message;
                    break;
                case UserAlreadyExistsException exe:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    message = ex.Message;
                    break;

                case FormatException exe:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    message = " Invalid format ";
                    break;
                case ArgumentException exe:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                    message = ex.Message;
                    break;
                case InvalidOperationException exe:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;

                 case NullReferenceException exe:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;
               
                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    message = "Internal server error";
                    break;

            }
            _logger.LogError(ex.Message, ex.StackTrace);
            var result = JsonSerializer.Serialize(new { errorMessage = message });
            await httpContext.Response.WriteAsync(result);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        } 
    }
}
