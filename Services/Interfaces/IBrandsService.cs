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
    public Task<IServiceResult<IEnumerable<BrandDto>>> GetAllBrandsAsync();

    /// <summary>
    /// Создать бренд
    /// </summary>
    /// <param name="createBrandRequest"></param>
    public Task<IServiceResult> CreateBrandAsync(CreateBrandRequest createBrandRequest);

    /// <summary>
    /// Обновить бренд
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult> UpdateBrandAsync(UpdateBrandRequest updateBrandRequest);

    /// <summary>
    /// Soft delete
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult> SoftDeleteBrandAsync(int id);


    /// <summary>
    /// Получить все размеры по бренду
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<IServiceResult<IEnumerable<AllowedSizeDto>>> GetAllSizesByBrandIdAsync(int id);

    /// <summary>
    /// Создать размер
    /// </summary>
    /// <param name="id"></param>
    /// <param name="createSizeRequest"></param>
    /// <returns></returns>
    public Task<IServiceResult> CreateSizeAsync(int id, CreateSizeRequest createSizeRequest);

    /// <summary>
    /// Обновить размер в бренде
    /// </summary>
    /// <param name="brandId"></param>
    /// <param name="sizeId"></param>
    /// <param name="updateSizeRequest"></param>
    /// <returns></returns>
    public Task<IServiceResult> UpdateSizeAsync(int brandId, int sizeId, UpdateSizeRequest updateSizeRequest);

    /// <summary>
    /// Обновить список размеров в бренде
    /// </summary>
    /// <param name="brandId"></param>
    /// <param name="updateSizesInBrandRequest"></param>
    /// <returns></returns>
    public Task<IServiceResult> UpdateSizesInBrandAsync(int brandId, UpdateSizesInBrandRequest updateSizesInBrandRequest);

    /// <summary>
    /// Soft delete
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult> SoftDeleteSizeAsync(int brandId, int id);
}