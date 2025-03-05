using E_Commerce_API.Application.DependencyInjection;
using E_Commerce_API.Infrastructure.Data;
using E_Commerce_API.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce_API.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddApplicationServices();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddDbContext<ApplicationDbContex>
            (option=> option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
