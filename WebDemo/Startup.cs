using FluentValidation;
using TodoApp.Models;
using WebDemo.Services;

namespace WebDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddCors();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<ITodoRepository, TodoRepository>();
            builder.Services.AddTransient<ITodo, Todo>();
            builder.Services.AddTransient<IValidator<Todo>, TodoValidator>();
        }
        public void Configure(IApplicationBuilder app)
        {
            //Write code here to configure the request processing pipeline
        }
        //Other members have been removed for brevity
    }
}