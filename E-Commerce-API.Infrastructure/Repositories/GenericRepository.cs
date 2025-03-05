using E_Commerce_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Infrastructure.Repositories
{
    internal class GenericRepository : IGenericRepository<T>
    {
        public Task<T> AddAsync(T entitiy)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(T entitiy)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(T entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
