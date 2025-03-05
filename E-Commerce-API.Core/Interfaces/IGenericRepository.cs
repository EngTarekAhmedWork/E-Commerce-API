using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<T> AddAsync(T entitiy);
        void UpdateAsync(T entitiy);
        void DeleteAsync(T entitiy);
        Task SaveAsync();

    }
}
