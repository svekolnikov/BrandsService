using BrandsService.DAL.Repositories.Interfaces;
using BrandsService.DTO;
using BrandsService.Models;
using BrandsService.Requests;
using BrandsService.Services.Interfaces;

namespace BrandsService.Services
{
    public class AllowedSizesService : IAllowedSizesService
    {
        private readonly IRepository<AllowedSize> _repository;

        public AllowedSizesService(IRepository<AllowedSize> repository)
        {
            _repository = repository;
        }

        public async Task<IServiceResult<IEnumerable<AllowedSizeDto>>> GetAllAsync()
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
