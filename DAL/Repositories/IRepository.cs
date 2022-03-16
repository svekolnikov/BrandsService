using BrandsService.Models;

namespace BrandsService.DAL.Repositories;

public interface IRepository<T> where T : class, IEntity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancel = default);

    Task<T?> GetByIdAsync(int id, CancellationToken cancel = default);

    Task<int> AddAsync(T item, CancellationToken cancel = default);

    Task<bool> UpdateAsync(T item, CancellationToken cancel = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancel = default);
}