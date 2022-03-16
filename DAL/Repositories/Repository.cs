using BrandsService.Models;

namespace BrandsService.DAL.Repositories;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddAsync(T item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(T item, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }
}