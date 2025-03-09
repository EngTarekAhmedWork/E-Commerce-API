using E_Commerce_API.Core.Entities;
using E_Commerce_API.Infrastructure.Data;
using E_Commerce_API.Infrastructure.Repositories;

namespace E_Commerce_API.Core.Interfaces;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ApplicationDbContex _context;
    public OrderRepository(ApplicationDbContex context) : base(context)
    {
        _context = context;
    }
}
