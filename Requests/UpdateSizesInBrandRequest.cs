namespace BrandsService.Requests;

public class UpdateSizesInBrandRequest
{
    public IEnumerable<int> AllowedSizesIds { get; set; }
}