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
    public Task<IServiceResult<IEnumerable<BrandDto>>> GetAllAsync();

    /// <summary>
    /// Создать бренд
    /// </summary>
    /// <param name="createBrandRequest"></param>
    public Task<IServiceResult> CreateAsync(CreateBrandRequest createBrandRequest);

    /// <summary>
    /// Обновить бренд
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult> UpdateAsync(UpdateBrandRequest updateBrandRequest);

    /// <summary>
    /// Soft delete
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult> SoftDeleteAsync(int id);
}