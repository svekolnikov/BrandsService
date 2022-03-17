using BrandsService.Models.Base;

namespace BrandsService.Models;

/// <summary>
/// Бренд (компания)
/// </summary>
public class Brand : NamedEntity
{
    /// <summary>
    /// Список допустимых размеров одежды
    /// </summary>
    public IEnumerable<Size> AllowedSizes { get; set; } = null!;
}