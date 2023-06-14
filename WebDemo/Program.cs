using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TodoApp.Models;
using WebDemo.Services;

namespace WebDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddCors();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<ITodoRepository, TodoRepository>();
            builder.Services.AddTransient<IVendorRepository, VendorRepository>();
            // builder.Services.AddTransient<ITodo, Todo>();
            // builder.Services.AddTransient<IValidator<Todo>, TodoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TodoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<VendorValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                //app.UseCors(x => x
                //  .AllowAnyOrigin()
                //  .AllowAnyMethod()
                //  .AllowAnyHeader());
            }

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}