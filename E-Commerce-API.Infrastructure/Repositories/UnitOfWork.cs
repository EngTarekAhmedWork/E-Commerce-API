using E_Commerce_API.Core.Interfaces;
using E_Commerce_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContex _context;

    public ICategoryRepository Category { get; }
    public IProductRepository Product { get; }
    public IOrderRepository Order { get; }
    public IOrderDetailsRepository OrderDetails { get; }
    public IUserRepository User { get; }

    public UnitOfWork(ApplicationDbContex context)
    {
        _context = context;
        Category = new CategoryRepository(context);
        Product = new ProductRepository(context);
        Order = new OrderRepository(context);
        OrderDetails = new OrderDetailsRepository(context);
        User = new UserRepository(context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

   
}
