

namespace MultiShop.Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);// Continue to the next middleware
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UnHandled");

                // Handle the exception and provide a user-friendly response
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsync("Internal Server Error. Please try again later.");

            }
        }
    }
}
