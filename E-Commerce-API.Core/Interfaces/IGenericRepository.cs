using System.Linq.Expressions;

namespace E_Commerce_API.Core.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? perdicate = null, string? includeEntity = null);
    T GetFirstOrDefault(Expression<Func<T, bool>>? perdicate = null, string? includeEntity = null);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
    void DeleteRange(IEnumerable<T> items);

    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, string? includeEntities = null);
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null, string? includeEntities = null);
    Task AddAsync(T item);
    Task UpdateAsync(T item);
    Task DeleteAsync(T item);
    Task DeleteRangeAsync(IEnumerable<T> items);
}
