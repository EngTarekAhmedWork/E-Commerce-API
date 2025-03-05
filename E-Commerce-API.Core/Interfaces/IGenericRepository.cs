using System.Linq.Expressions;

namespace E_Commerce_API.Core.Interfaces;

public interface IGenericRepository<T> where T : class
{
    //Task<IEnumerable<T>> GetAllAsync();
    //Task<T> GetByIdAsync(int Id);
    //Task<T> AddAsync(T entitiy);
    //void UpdateAsync(T entitiy);
    //void DeleteAsync(T entitiy);
    //Task SaveAsync();
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? perdicate = null, string? includeEntity = null);
    T GetFirstOrDefault(Expression<Func<T, bool>>? perdicate = null, string? includeEntity = null);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
    void DeleteRange(IEnumerable<T> items);
}
