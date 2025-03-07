using E_Commerce_API.Core.Entities;

namespace E_Commerce_API.Application.Services;

public interface IOrderDetailsService
{
    Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync();
    Task CreateOrderDetailsAsync(OrderDetails orderDetails);
    Task DeleteOrderDetailsAsync(int Id);
    Task UpdateOrderDetailsAsync(int Id,OrderDetails orderDetails);
}
