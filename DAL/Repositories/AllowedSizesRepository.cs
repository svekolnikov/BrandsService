using BrandsService.DAL.Context;
using BrandsService.DAL.Repositories.Interfaces;
using BrandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandsService.DAL.Repositories;

public class AllowedSizesRepository : DbRepository<AllowedSize>, IAllowedSizesRepository
{
    public AllowedSizesRepository(
        ApplicationDbContext dbContext,
        ILogger<DbRepository<AllowedSize>> logger)
        : base(dbContext, logger)
    {}

    public async Task<AllowedSize?> GetBySizeRfInBrand(string sizeRf, int brandId)
    {
        var result = await Items
            .Where(x => x.IsDeleted == false && x.BrandId == brandId)
            .SingleOrDefaultAsync(x => x.Rf == sizeRf);

        return result;
    }

    public async Task<IEnumerable<AllowedSize>> GetAllSizesByBrandIdAsync(int id)
    {
        var result = await Items
            .Where(x => x.IsDeleted == false && x.BrandId == id)
            .ToListAsync();

        return result;
    }
}