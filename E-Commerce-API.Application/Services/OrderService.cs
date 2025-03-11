using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;

namespace E_Commerce_API.Application.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;


    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        await _unitOfWork.Order.AddAsync(order);
        await _unitOfWork.CompleteAsync();
        return order;
    }

    public async Task DeleteOrderAsync(int Id)
    {
        var result = await _unitOfWork.Order.GetFirstOrDefaultAsync(x => x.Id == Id);
        _unitOfWork.Order.Delete(result);
    }

    public async Task<IEnumerable<Order>> GetAllOrderAsync()
    {
        return await _unitOfWork.Order.GetAllAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.Order.GetFirstOrDefaultAsync(x=> x.Id == id);
        return result;
    }

    public async Task UpdateOrderAsync(int Id, Order order)
    {
        var result = await _unitOfWork.Order.GetFirstOrDefaultAsync(x => x.Id == Id);
        result.OrderStatus = order.OrderStatus;
        result.OrderPrice = order.OrderPrice;
        result.UserId = order.UserId;
        await _unitOfWork.Order.UpdateAsync(result);
    }
}
