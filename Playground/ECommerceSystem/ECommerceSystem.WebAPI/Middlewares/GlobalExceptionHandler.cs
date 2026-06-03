using ECommerceSystem.WebAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace ECommerceSystem.WebAPI.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IHostEnvironment _env;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Sistemde beklenmedik bir hata meydana geldi: {Message}", exception.Message);

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var response = new ErrorResponse
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = "Sistemde beklenmedik bir teknik hata oluştu. Lütfen daha sonra tekrar deneyiniz."
            };

            if (_env.IsDevelopment())
            {
                response.Detail = exception.StackTrace;
                response.Message = exception.Message; 
            }

            var jsonResponse = JsonSerializer.Serialize(response);
            await httpContext.Response.WriteAsync(jsonResponse, cancellationToken);

            return true;

        }
    }
}
