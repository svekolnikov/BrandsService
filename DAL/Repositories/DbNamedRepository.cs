using BrandsService.DAL.Context;
using BrandsService.DAL.Repositories.Interfaces;
using BrandsService.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrandsService.DAL.Repositories;

public class DbNamedRepository<T> : DbRepository<T>, INamedRepository<T> where T : class, INamedEntity
{
    public DbNamedRepository(ApplicationDbContext dbContext, ILogger<DbNamedRepository<T>> logger) : base(dbContext, logger)
    {
    }

    public async Task<T?> GetByNameAsync(string name, CancellationToken cancel = default)
    {
        return await Items.FirstOrDefaultAsync(item =>
                item.Name == name, cancel)
            .ConfigureAwait(false);
    }
}