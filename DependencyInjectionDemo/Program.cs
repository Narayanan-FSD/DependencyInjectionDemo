
using DependencyInjectionDemo.BusinessLayer;
using DependencyInjectionDemo.DataAccessLayer;

namespace DependencyInjectionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Host.UseDefaultServiceProvider(opt =>
            //{
            //    opt.ValidateScopes = true;
            //});

            builder.Services.AddControllers();

            builder.Services.AddScoped<IDataAccessService,DataAccessService>();
            builder.Services.AddSingleton<IBusinessService,BusinessService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
