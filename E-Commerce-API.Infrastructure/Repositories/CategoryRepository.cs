using E_Commerce_API.Core.Entities;
using E_Commerce_API.Infrastructure.Data;
using E_Commerce_API.Infrastructure.Repositories;

namespace E_Commerce_API.Core.Interfaces;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContex _context;
    public CategoryRepository(ApplicationDbContex context) : base(context)
    {
        _context = context;
    }
}
