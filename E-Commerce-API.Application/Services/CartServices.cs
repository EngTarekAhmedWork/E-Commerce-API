using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Application.Services
{
    public class CartServices : ICartServices
    {
        private readonly IUnitOfWork _work;

        public CartServices(IUnitOfWork work)
        {
            _work = work;
        }
        public async Task CreateAsync(Cart cart)
        {
            await _work.Cart.AddAsync(cart);
            
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _work.Cart.GetFirstOrDefaultAsync(x => x.Id == id);
            await _work.Cart.DeleteAsync(result);
            
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _work.Cart.GetAllAsync();  
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            var result = await _work.Cart.GetFirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Cart> GetCartItemAsync(int UserId, int ProductId)
        {
            var result = await _work.Cart.GetFirstOrDefaultAsync(x => x.UserId == UserId && x.ProductId==ProductId);
            return result;
        }

        public async Task UpdateAsync(Cart cart , int Id)
        {
            var result = await _work.Cart.GetFirstOrDefaultAsync(x=> x.Id == Id);
            await _work.Cart.UpdateAsync(result);
            
        }
    }
}
