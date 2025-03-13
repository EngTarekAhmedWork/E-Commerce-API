namespace E_Commerce_API.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Category { get; }
    IProductRepository Product { get; }
    IOrderRepository Order { get; }
    IOrderDetailsRepository OrderDetails { get; }
    IUserRepository User { get; }

    ICartRepository Cart { get; }

    Task<int> CompleteAsync();
}
