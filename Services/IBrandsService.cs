using BrandsService.DTO;
using BrandsService.Requests;

namespace BrandsService.Services;

/// <summary>
/// Сервис работы с брендами
/// </summary>
public interface IBrandsService
{
    /// <summary>
    /// Получить все бренды
    /// </summary>
    /// <returns></returns>
    public IEnumerable<BrandDto> GetBrands();

    /// <summary>
    /// Создать бренд
    /// </summary>
    /// <param name="createBrandRequest"></param>
    public void CreateBrand(CreateBrandRequest createBrandRequest);
}