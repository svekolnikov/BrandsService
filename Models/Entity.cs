using BrandsService.Models.Interfaces;

namespace BrandsService.Models;
public abstract class Entity : IEntity
{
    public int Id { get; set; }
}