using BrandsService.Models.Interfaces;

namespace BrandsService.Models.Base;
public abstract class Entity : IEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
}