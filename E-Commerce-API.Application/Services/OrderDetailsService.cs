using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;

namespace E_Commerce_API.Application.Services;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderDetailsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task CreateOrderDetailsAsync(OrderDetails orderDetails)
    {
        await _unitOfWork.OrderDetails.AddAsync(orderDetails);
    }

    public async Task DeleteOrderDetailsAsync(int Id)
    {
        var result = await _unitOfWork.OrderDetails.GetFirstOrDefaultAsync(x => x.Id == Id);
        await _unitOfWork.OrderDetails.DeleteAsync(result);
    }

    public Task<IEnumerable<OrderDetails>> GetAllOrderDetailsAsync()
    {
        return _unitOfWork.OrderDetails.GetAllAsync();
    }

    public async Task<OrderDetails> GetByIdAsync(int id)
    {
        var result = await _unitOfWork.OrderDetails.GetFirstOrDefaultAsync(x=> x.Id == id);
        return result;
    }

    public async Task UpdateOrderDetailsAsync(int Id, OrderDetails orderDetails)
    {
        var result = await _unitOfWork.OrderDetails.GetFirstOrDefaultAsync(x=>x.Id == Id);
        result.Order = orderDetails.Order;
        result.Quantity = orderDetails.Quantity;
        result.OrderId = orderDetails.OrderId;
        result.Price = orderDetails.Price;
        await _unitOfWork.OrderDetails.UpdateAsync(result);
    }
}
