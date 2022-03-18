using BrandsService.DTO;
using BrandsService.Requests;
using BrandsService.Services.Interfaces;

namespace BrandsService.Services
{
    public class SizesService : ISizesService
    {
        public async Task<IServiceResult<IEnumerable<SizeDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IServiceResult> CreateAsync(CreateSizeRequest createSizeRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IServiceResult> UpdateAsync(UpdateSizeRequest updateSizeRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IServiceResult> SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
