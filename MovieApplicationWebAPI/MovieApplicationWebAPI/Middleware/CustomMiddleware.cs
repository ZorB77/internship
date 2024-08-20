using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MovieApplicationWebAPI.Custom_Exceptions;

namespace MovieApplicationWebAPI.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        private void LogRequest(HttpContext context)
        {
            var request = context.Request;

            var requestLog = new StringBuilder();
            requestLog.AppendLine("Incoming Request:");
            requestLog.AppendLine($"HTTP {request.Method} {request.Path}");
            requestLog.AppendLine($"Host: {request.Host}");
            requestLog.AppendLine($"Content-Type: {request.ContentType}");
            requestLog.AppendLine($"Content-Length: {request.ContentLength}");

            _logger.LogInformation(requestLog.ToString());
        }

        private void LogResponse(HttpContext context)
        {
            var response = context.Response;

            var responseLog = new StringBuilder();
            responseLog.AppendLine("Outgoing Response:");
            responseLog.AppendLine($"HTTP {response.StatusCode}");
            responseLog.AppendLine($"Content-Type: {response.ContentType}");
            responseLog.AppendLine($"Content-Length: {response.ContentLength}");

            _logger.LogInformation(responseLog.ToString());
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                LogRequest(context);

                await _next(context);

                LogResponse(context);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError($"ArgumentNullException: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Bad Request: Missing argument.");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError($"InvalidOperationException: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal Server Error: Invalid operation.");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError($"UnauthorizedAccessException: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Access is denied.");
            }
            catch (NotSupportedException ex)
            {
                _logger.LogError($"NotSupportedException: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
                await context.Response.WriteAsync("Method Not Allowed: Operation not supported.");
            }
            catch (PersonSalaryNotInRangeException ex)
            {
                _logger.LogError($"PersonSalaryNotInRangeException: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Bad Request: The salary of the person is not in range.");
            }
            catch (MovieDoesNotExistException ex)
            {
                _logger.LogError($"MovieDoesNotExistException: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Bad Request: The movie cannot be null.");
            }
            catch (MovieNameIsNullException ex)
            {
                _logger.LogError($"MovieNameIsNullException: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Bad Request: The name of a movie cannot be null.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Internal Server Error: An unexpected error occurred.");
            }
        }
    }
}
