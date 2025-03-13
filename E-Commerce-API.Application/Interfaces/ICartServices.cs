using E_Commerce_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Application.Interfaces
{
    public interface ICartServices
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart> GetByIdAsync(int id);
        Task<Cart> GetCartItemAsync(int UserId, int ProductId);
        Task CreateAsync(Cart cart);
        
        Task UpdateAsync(Cart cart , int Id);

        Task DeleteAsync(int id);
    }
}
