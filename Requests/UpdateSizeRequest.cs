namespace BrandsService.Requests;

public class UpdateSizeRequest
{
    public int Id { get; set; }
    public string Rf { get; set; } = null!;
    public string Own { get; set; } = null!;
}