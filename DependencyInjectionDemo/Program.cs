
using DependencyInjectionDemo.Middlewares;
using System.Net;

namespace DependencyInjectionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<DependencyInjectedMiddleware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ConventionalMiddleware>();
            app.UseMiddleware<DependencyInjectedMiddleware>();
            app.Use(async (context, next) =>
            {
                var logger = context.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("Inline UseMiddleware");
                logger.LogInformation("Inline UseMiddleware Before");
                await next(context);
                logger.LogInformation("Inline UseMiddleware After");
            });

            app.MapControllers();

            app.Map("/weatherforecast", builder => {

                builder.Use(async (context, next) =>
                {
                    await next(context);
                });

                builder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("weatherforecast called in branching");
                });

            });

            app.MapGet("/hello", () =>
            {
                return "hello world";
            });

            //app.Run(async (context) =>
            //{
            //    var response = new
            //    {
            //        status = HttpStatusCode.InternalServerError,
            //        message = "Application shut down"
            //    };
            //    await context.Response.WriteAsJsonAsync(response);
            //});

            app.Run();
        }
    }
}
