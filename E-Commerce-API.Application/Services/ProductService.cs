using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;

namespace E_Commerce_API.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateProductAsync(Product product)
    {
        await _unitOfWork.Product.AddAsync(product);
    }

    public async Task DeleteProductAsync(int Id)
    {
        var result = await _unitOfWork.Product.GetFirstOrDefaultAsync(m=> m.Id == Id);
        await _unitOfWork.Product.DeleteAsync(result);
    }

    public async Task<IEnumerable<Product>> GetAllProductAsync()
    {
        return await _unitOfWork.Product.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _unitOfWork.Product.GetFirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateProductAsync(Product product, int Id)
    {
        var result = await _unitOfWork.Product.GetFirstOrDefaultAsync(m=> m.Id == Id);
        result.ProductName = product.ProductName;
        result.ProductPrice = product.ProductPrice;
        result.ProductDescription = product.ProductDescription;
        result.Category = product.Category;
        await _unitOfWork.Product.UpdateAsync(result);
    }
}
