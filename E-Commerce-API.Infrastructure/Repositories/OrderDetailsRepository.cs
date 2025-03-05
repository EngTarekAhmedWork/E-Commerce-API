using E_Commerce_API.Core.Entities;
using E_Commerce_API.Infrastructure.Data;
using E_Commerce_API.Infrastructure.Repositories;

namespace E_Commerce_API.Core.Interfaces;

public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
{
    public OrderDetailsRepository(ApplicationDbContex context) : base(context)
    {
    }
}
