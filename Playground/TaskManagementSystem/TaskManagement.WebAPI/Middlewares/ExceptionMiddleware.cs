using FluentValidation;
using System.Net;
using TaskManagement.WebAPI.Models;

namespace TaskManagement.WebAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sistemde beklenmeyen bir hata oluştu: {Message}", ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var errorDetails = new ErrorDetails
            {
                Message = "Sunucu taraflı bir hata oluştu." 
            };

            switch (exception)
            {
                case ValidationException valEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorDetails.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorDetails.Message = "Validasyon hatası gerçekleşti.";
                    errorDetails.Details = string.Join(" | ", valEx.Errors.Select(x => x.ErrorMessage));
                    break;

                case KeyNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetails.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetails.Message = exception.Message;
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorDetails.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorDetails.Details = _env.IsDevelopment() ? exception.StackTrace : null;
                    if (_env.IsDevelopment())
                    {
                        errorDetails.Message = exception.Message;
                    }
                    break;
            }

            await context.Response.WriteAsync(errorDetails.ToString());
        }
    }


}
