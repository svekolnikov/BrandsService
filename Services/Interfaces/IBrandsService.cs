using BrandsService.DTO;
using BrandsService.Requests;

namespace BrandsService.Services.Interfaces;

/// <summary>
/// Сервис работы с брендами
/// </summary>
public interface IBrandsService
{
    /// <summary>
    /// Получить все бренды
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult<IEnumerable<BrandDto>>> GetBrands();

    /// <summary>
    /// Создать бренд
    /// </summary>
    /// <param name="createBrandRequest"></param>
    public Task<IServiceResult> CreateBrand(CreateBrandRequest createBrandRequest);

    /// <summary>
    /// Обновить бренд
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult> UpdateBrand(UpdateBrandRequest updateBrandRequest);

    /// <summary>
    /// Удалить бренд
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult> SoftDeleteBrand(int id);
}