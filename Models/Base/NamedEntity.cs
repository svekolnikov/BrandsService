using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrandsService.Models.Interfaces;

namespace BrandsService.Models.Base;

public class NamedEntity : Entity, INamedEntity
{
    /// <summary>
    /// Название
    /// </summary>
    [Column(TypeName = "nvarchar(200)")]
    [Required]
    public string Name { get; set; } = null!;

    public override string ToString()
    {
        return Name;
    }
}