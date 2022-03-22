namespace BrandsService.Models.Interfaces;
public interface IEntity
{
    int Id { get; set; }
    bool IsDeleted { get; set; }
}