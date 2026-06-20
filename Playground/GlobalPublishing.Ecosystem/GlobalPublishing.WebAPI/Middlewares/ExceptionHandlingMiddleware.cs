using System.Net;
using System.Text.Json;

namespace GlobalPublishing.WebAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Uygulamada hata meydana geldi! Hata Mesajı: {Message}",ex.Message)
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "Sistemde beklenmeyen bir hata oluştu.";
        
            if(exception is ArgumentException || exception is ArgumentOutOfRangeException)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = exception.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = message,
                Detailed = exception.InnerException?.Message ?? exception.Message
            };

            var jsonResult = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResult);
        }
    }
}
