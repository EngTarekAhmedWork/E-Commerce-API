using E_Commerce_API.Core.Entities;

namespace E_Commerce_API.Application.Services;

public interface IOrderDetailsService
{
    Task<List<OrderDetails>> GetOrderDetailsAsync();
    Task<OrderDetails> GetByIdOrderDetailsAsync(int Id);
    Task<OrderDetails> CreateOrderDetailsAsync(OrderDetails orderDetails);
    Task<OrderDetails> UpdateOrderDetailsAsync(OrderDetails orderDetails, int Id);
    Task<OrderDetails> DeleteOrderDetailsAsync(int Id);
}
