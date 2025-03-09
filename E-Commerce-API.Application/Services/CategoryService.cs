using E_Commerce_API.Core.Entities;
using E_Commerce_API.Core.Interfaces;

namespace E_Commerce_API.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task CreateCategoryAsync(Category category)
    {
        await _unitOfWork.Category.AddAsync(category);
    }

    public async Task DeleteCategoryAsync(int Id)
    {
        var result = await _unitOfWork.Category.GetFirstOrDefaultAsync(x => x.Id == Id);
        await _unitOfWork.Category.DeleteAsync(result);
    }

    public async Task<IEnumerable<Category>> GetAllCategoryAsync()
    {
        return await _unitOfWork.Category.GetAllAsync(); 
    }

    public async Task<Category> GetByIdAsync(int Id)
    {
        var result = await _unitOfWork.Category.GetFirstOrDefaultAsync(x=> x.Id == Id);
        return result;
    }

    public async Task UpdateCategoryAsync(int Id, Category category)
    {
        var result = await _unitOfWork.Category.GetFirstOrDefaultAsync(x => x.Id == Id);
        result.Name = category.Name;
        result.Description = category.Description;
        await _unitOfWork.Category.UpdateAsync(result);
    }
}
