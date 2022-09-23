using BookStoreApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddDbContext<BooksContext>(opt => opt.UseInMemoryDatabase("BookStoreApi"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            //var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            //using (var scope = scopedFactory.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetService<BooksContext>();
            //    context.Database
            //    context.EnsureSeeded();
            //}


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