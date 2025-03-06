using E_Commerce_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product, int Id);
        Task<Product> DeleteProductAsync(int Id);
    }
}
