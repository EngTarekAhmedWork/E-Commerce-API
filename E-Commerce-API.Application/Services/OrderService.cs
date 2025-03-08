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


        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
        }

        public async Task DeleteOrderAsync(int Id)
        {
            var result = await _orderRepository.GetFirstOrDefaultAsync(x => x.Id == Id);
            _orderRepository.Delete(result);
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var result = await _orderRepository.GetFirstOrDefaultAsync(x=> x.Id == id);
            return result;
        }

        public async Task UpdateOrderAsync(int Id, Order order)
        {
            var result = await _orderRepository.GetFirstOrDefaultAsync(x => x.Id == Id);
            result.OrderStatus = order.OrderStatus;
            result.OrderPrice = order.OrderPrice;
            result.UserId = order.UserId;
            await _orderRepository.UpdateAsync(result);
        }
    }
}
