using System.ComponentModel.DataAnnotations;

namespace BrandsService.Models;

/// <summary>
/// Размер, устанавливает связь размера бренда и размера РФ
/// </summary>
public class Size : Entity
{
    /// <summary>
    /// Размер РФ
    /// </summary>
    [Required]
    public string RF { get; set; } = null!;

    /// <summary>
    /// Размер бренда
    /// </summary>
    [Required]
    public string Own { get; set; } = null!;
}