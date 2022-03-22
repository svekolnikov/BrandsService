using System.ComponentModel.DataAnnotations;
using BrandsService.DTO;

namespace BrandsService.Requests
{
    public class UpdateBrandRequest
    {
        [Required]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; } = null!;
    }
}
