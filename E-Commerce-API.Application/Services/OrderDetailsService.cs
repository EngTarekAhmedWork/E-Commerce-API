using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Application.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        public async Task CreateOrderDetailsAsync(OrderDetails orderDetails)
        {
            await _orderDetailsRepository.AddAsync(orderDetails);
        }

        public async Task DeleteOrderDetailsAsync(int Id)
        {
            var result = await _orderDetailsRepository.GetFirstOrDefaultAsync(x => x.Id == Id);
            await _orderDetailsRepository.DeleteAsync(result);
        }

        public Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync()
        {
            return _orderDetailsRepository.GetAllAsync();
        }

        public async Task UpdateOrderDetailsAsync(int Id, OrderDetails orderDetails)
        {
            var result = await _orderDetailsRepository.GetFirstOrDefaultAsync(x=>x.Id == Id);
            result.Order = orderDetails.Order;
            result.Quantity = orderDetails.Quantity;
            result.OrderId = orderDetails.OrderId;
            result.Price = orderDetails.Price;
            await _orderDetailsRepository.UpdateAsync(result);
        }
    }
}
