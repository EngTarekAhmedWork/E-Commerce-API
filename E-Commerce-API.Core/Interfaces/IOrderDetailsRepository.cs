﻿using E_Commerce_API.Core.Entities;

namespace E_Commerce_API.Core.Interfaces;

public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
{
    Task<List<OrderDetails>>  GetOrderDetailsAsync();
    Task<OrderDetails> GetByIdOrderDetailsAsync(int Id);
    Task<OrderDetails> CreateOrderDetailsAsync(OrderDetails orderDetails);

    Task<OrderDetails> UpdateOrderDetailsAsync(OrderDetails orderDetails, int Id);
    Task<OrderDetails> DeleteOrderDetailsAsync(int Id);

}
