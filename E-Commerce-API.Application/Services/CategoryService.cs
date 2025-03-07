using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task CreateCategoryAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task DeleteCategoryAsync(int Id)
        {
            var result = await _categoryRepository.GetFirstOrDefaultAsync(x => x.Id == Id);
            await _categoryRepository.DeleteAsync(result);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllAsync(); 
        }

        public async Task UpdateCategoryAsync(int Id, Category category)
        {
            var result = await _categoryRepository.GetFirstOrDefaultAsync(x => x.Id == Id);
            result.Id = category.Id;
            result.Name = category.Name;
            result.Description = category.Description;
            await _categoryRepository.UpdateAsync(result);
        }
    }
}
