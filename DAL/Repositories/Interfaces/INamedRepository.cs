using BrandsService.Models;
using BrandsService.Models.Interfaces;

namespace BrandsService.DAL.Repositories.Interfaces;

public interface INamedRepository<T> : IRepository<T> where T : class, IEntity
{
    Task<T?> GetByNameAsync(string name, CancellationToken cancel = default);
}