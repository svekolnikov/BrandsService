using BrandsService.DTO;
using BrandsService.Requests;

namespace BrandsService.Services.Interfaces;

/// <summary>
/// Сервис работы с размерами
/// </summary>
public interface IAllowedSizesService
{
    /// <summary>
    /// Получить все размеры
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult<IEnumerable<AllowedSizeDto>>> GetAllAsync();

    /// <summary>
    /// Создать размер
    /// </summary>
    /// <param name="createSizeRequest"></param>
    /// <returns></returns>
    public Task<IServiceResult> CreateAsync(CreateSizeRequest createSizeRequest);

    /// <summary>
    /// Обновить размер
    /// </summary>
    /// <param name="updateSizeRequest"></param>
    /// <returns></returns>
    public Task<IServiceResult> UpdateAsync(UpdateSizeRequest updateSizeRequest);

    /// <summary>
    /// Soft delete
    /// </summary>
    /// <returns></returns>
    public Task<IServiceResult> SoftDeleteAsync(int id);
}