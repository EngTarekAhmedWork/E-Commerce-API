using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            var result = await _productRepository.AddAsync(product);
            return result;
        }

        public async Task<Product> DeleteProductAsync(int Id)
        {
            var result = await _productRepository.GetFirstOrDefaultAsync(m=> m.Id == Id);
            await _productRepository.DeleteAsync(result);
            return result;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product, int Id)
        {
            var result = await _productRepository.GetFirstOrDefaultAsync(m=> m.Id == Id);
            result.ProductName = product.ProductName;
            result.ProductPrice = product.ProductPrice;
            result.ProductDescription = product.ProductDescription;
            result.Category = product.Category;
            await _productRepository.UpdateAsync(result);
            return result;
        }
    }
}
