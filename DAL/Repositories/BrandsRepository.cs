using BrandsService.DAL.Context;
using BrandsService.DAL.Repositories.Interfaces;
using BrandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandsService.DAL.Repositories;

public class BrandsRepository : DbNamedRepository<Brand>, IBrandsRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<BrandsRepository> _logger;

    public BrandsRepository(ApplicationDbContext dbContext, ILogger<BrandsRepository> logger) 
        : base(dbContext, logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Brand>> GetAllWithSizesAsync(CancellationToken cancel = default)
    {
        var result = await Items
            .Include(x => x.AllowedSizes)
            .ToArrayAsync(cancel);

        return result;
    }
}