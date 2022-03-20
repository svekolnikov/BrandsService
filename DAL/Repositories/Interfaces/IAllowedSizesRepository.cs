using BrandsService.Models;

namespace BrandsService.DAL.Repositories.Interfaces;

public interface IAllowedSizesRepository : IRepository<AllowedSize>
{
    Task<AllowedSize?> GetBySizeRfInBrand(string sizeRf, int brandId);
    Task<IEnumerable<AllowedSize>> GetAllSizesByBrandIdAsync(int id);
}