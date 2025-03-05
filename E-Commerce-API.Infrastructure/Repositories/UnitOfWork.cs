using E_Commerce_API.Core.Interfaces;
using E_Commerce_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContex _context;
    public ICategoryRepository Category {  get; set; }
    public IProductRepository Product { get; set; }
    public IOrderRepository Order { get; set; }
    public IOrderDetailsRepository OrderDetails { get; set; }
    public IUserRepository User { get; set; }

    public UnitOfWork(ApplicationDbContex context)
    {
        _context = context;
        Category = new CategoryRepository(context);
        Product = new ProductRepository(context);
        Order = new OrderRepository(context);
        OrderDetails = new OrderDetailsRepository(context);
        User = new UserRepository(context);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
