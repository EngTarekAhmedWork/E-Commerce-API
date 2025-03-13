using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Application.Services;
using E_Commerce_API.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_API.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICartServices, CartServices>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrderDetailsService, OrderDetailsService>();

        return services;

    }
}
