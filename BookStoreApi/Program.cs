using BookStoreApi.Contexts;
using BookStoreApi.Helpers;
using BookStoreApi.Repositories.UnitOfWork;
using BookStoreApi.Repositories.BooksRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.OpenApi.Models;
using BookStoreApi.Repositories.AuthorsRepository;
using BookStoreApi.Repositories.AppUsersRepository;
using Swashbuckle.AspNetCore.Filters;
using BookStoreApi.Services;
using FluentValidation.AspNetCore;

namespace BookStoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("BookStoreApi"));
            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IBooksRepository, BooksRepository>();
            builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            builder.Services.AddScoped<IAppUsersRepository, AppUsersRepository>();
            builder.Services.AddScoped<IBooksService, BooksService>();
            builder.Services.AddScoped<AuthUtils>();
            builder.Services.AddTransient<DbSeeder>();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddFluentValidation(config => config.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        //ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true
                    };
                });

            builder.Services.AddSwaggerGen(opts => {
                opts.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (Bearer {token})",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                opts.OperationFilter<SecurityRequirementsOperationFilter>();
            });


            var app = builder.Build();

            app.UseCors();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
                using (var scope = scopedFactory.CreateScope())
                {
                    var dbSeeder = scope.ServiceProvider.GetService<DbSeeder>();
                    dbSeeder.Seed();
                }
            }


            app.UseHttpsRedirection();

            app.UseAuthentication();//PhD

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}