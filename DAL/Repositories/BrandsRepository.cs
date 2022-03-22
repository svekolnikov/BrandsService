using BrandsService.DAL.Context;
using BrandsService.DAL.Repositories.Interfaces;
using BrandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandsService.DAL.Repositories;

public class BrandsRepository : DbNamedRepository<Brand>, IBrandsRepository
{
    public BrandsRepository(ApplicationDbContext dbContext, ILogger<BrandsRepository> logger) 
        : base(dbContext, logger)
    {
    }

    public async Task<IEnumerable<Brand>> GetAllWithSizesAsync(CancellationToken cancel = default)
    {
        var result = await Items
            .Include(x => x.AllowedSizes
                .Where(d => !d.IsDeleted))
            .Where(x => !x.IsDeleted)
            .ToArrayAsync(cancel);

        return result;
    }

    public async Task<Brand?> GetByIdWithSizesAsync(int id, CancellationToken cancel = default)
    {
        var result = await Set
            .Include(x => x.AllowedSizes)
            .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancel);

        return result;
    }
}