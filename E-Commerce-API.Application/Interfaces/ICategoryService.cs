using E_Commerce_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task CreateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int Id);
        Task UpdateCategoryAsync(int Id, Category category);
    }
}
