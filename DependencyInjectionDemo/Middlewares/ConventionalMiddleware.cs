namespace DependencyInjectionDemo.Middlewares
{
    public class ConventionalMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ConventionalMiddleware> _logger;

        public ConventionalMiddleware(RequestDelegate next, ILogger<ConventionalMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _logger.LogInformation("Conventional constructor called");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Conventional Before");
            await _next(context);
            _logger.LogInformation("Conventional After");

        }
    }
}
