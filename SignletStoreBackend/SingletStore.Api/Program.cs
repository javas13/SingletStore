
using Microsoft.EntityFrameworkCore;
using SingletStore.Application.Services;
using SingletStore.DataAccess;
using SingletStore.DataAccess.Repositories;

namespace SingletStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SingletStoreDbContext>(
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(SingletStoreDbContext)));
                });

            builder.Services.AddScoped<ISingletsService, SingletsService>();
            builder.Services.AddScoped<ISingletsRepository, SingletsRepository>();

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

            app.UseCors(x =>
            {
                x.WithHeaders().AllowAnyHeader();
                x.WithOrigins("http://localhost:3000");
                x.WithMethods().AllowAnyMethod();
            });

            app.Run();
        }
    }
}
