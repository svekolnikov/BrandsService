namespace BrandsService.Models
{
    public class Brand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Size> AllowedSizes { get; set; }
    }
}
