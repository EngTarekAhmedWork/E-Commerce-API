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
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order> GetByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task DeleteOrderAsync(int Id);
        Task UpdateOrderAsync(int Id,Order order);
    }
}
