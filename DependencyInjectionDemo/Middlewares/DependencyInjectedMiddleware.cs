namespace DependencyInjectionDemo.Middlewares
{
    public class DependencyInjectedMiddleware : IMiddleware
    {
        private readonly ILogger<DependencyInjectedMiddleware> _logger;
        public DependencyInjectedMiddleware(ILogger<DependencyInjectedMiddleware> logger)
        {
            _logger = logger;
            _logger.LogInformation("Dependency Injected constructor called");
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation("Dependency Injected Before");
            await next(context);
            _logger.LogInformation("Dependency Injected After");
        }
    }
}

