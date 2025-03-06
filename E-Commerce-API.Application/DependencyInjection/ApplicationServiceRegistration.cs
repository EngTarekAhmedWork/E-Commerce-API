using E_Commerce_API.Application.Services;
using E_Commerce_API.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_API.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        return services;

    }
}
