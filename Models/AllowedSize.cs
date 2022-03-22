using System.ComponentModel.DataAnnotations;
using BrandsService.Models.Base;

namespace BrandsService.Models;

/// <summary>
/// Размер, устанавливает связь размера бренда и размера РФ
/// </summary>
public class AllowedSize : Entity
{
    /// <summary>
    /// Размер РФ
    /// </summary>
    [Required]
    public string Rf { get; set; } = null!;

    /// <summary>
    /// Размер бренда
    /// </summary>
    [Required]
    public string Own { get; set; } = null!;

    public int BrandId { get; set; }
}