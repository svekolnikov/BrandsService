using System.ComponentModel.DataAnnotations;

namespace BrandsService.Models;

/// <summary>
/// Бренд (компания)
/// </summary>
public class Brand : Entity
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Список допустимых размеров одежды
    /// </summary>
    public IEnumerable<Size> AllowedSizes { get; set; } = null!;
}