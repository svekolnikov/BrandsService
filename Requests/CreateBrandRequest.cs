using BrandsService.DTO;

namespace BrandsService.Requests;

public class CreateBrandRequest
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;
}