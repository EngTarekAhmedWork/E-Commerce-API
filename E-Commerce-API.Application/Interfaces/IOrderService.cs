using E_Commerce_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.Interfaces
{
    public interface IOrderService 
    {
        Task<List<Order>> GetAllOrderAsync();
        Task<Order> GetByIdOrderAsync(int Id);
        Task<Order> CreateOrderDetailsAsync(Order order);

        Task<Order> UpdateOrderDetailsAsync(Order order, int Id);
        Task<Order> DeleteOrderDetailsAsync(int Id);
    }
}
