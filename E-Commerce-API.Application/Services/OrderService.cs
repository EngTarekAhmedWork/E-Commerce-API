using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        

        public OrderService(IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
            
        }

        public async Task<Order> CreateOrderDetailsAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> DeleteOrderDetailsAsync(int Id)
        {
            var result = await _orderRepository.GetFirstOrDefaultAsync(x => x.Id == Id);
            await _orderRepository.DeleteAsync(result);
            return result;

        }

        public async Task<Order> GetByIdOrderAsync(int Id)
        {
            var result = await _orderRepository.GetFirstOrDefaultAsync(o => o.Id == Id);
            //
        }

        public async Task<List<Order>> GetAllOrderAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        
        public Task<Order> UpdateOrderDetailsAsync(Order order, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
