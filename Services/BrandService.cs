using AutoMapper;
using BrandsService.DAL.Repositories.Interfaces;
using BrandsService.DTO;
using BrandsService.Models;
using BrandsService.Requests;
using BrandsService.Services.Interfaces;

namespace BrandsService.Services;

public class BrandService : IBrandsService
{
    private readonly INamedRepository<Brand> _repository;
    private readonly IMapper _mapper;

    public BrandService(INamedRepository<Brand> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить все бренды
    /// </summary>
    /// <returns></returns>
    public async Task<IServiceResult<IEnumerable<BrandDto>>> GetBrands()
    {
        var brandsEntities = await _repository.GetAllAsync();

        var brandsDto = _mapper.Map<List<BrandDto>>(brandsEntities); 

        return new ServiceResult<IEnumerable<BrandDto>>
        {
            Data = brandsDto
        };
    }

    /// <summary>
    /// Создать бренд
    /// </summary>
    /// <param name="createBrandRequest"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IServiceResult> CreateBrand(CreateBrandRequest createBrandRequest)
    {
        var duplicate = createBrandRequest
            .AllowedSizes.GroupBy(x => x.RF)
            .Where(x => x.Count() > 1)
            .Select(x => x.Key)
            .Count();

        if (duplicate > 0)
        {
            return new ServiceResult
            {
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation{Description = "В списке размеров бренда не может быть элементов с одинаковым размером РФ"}
                }
            };
        }

        var sameNameEntity = await _repository.GetByNameAsync(createBrandRequest.Name);

        if (sameNameEntity is not null)
        {
            return new ServiceResult
            {
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation{Description = $"Бренд с именем [{createBrandRequest.Name}] уже существует"}
                }
            };
        }

        var brandEntity = _mapper.Map<Brand>(createBrandRequest);

        await _repository.AddAsync(brandEntity);

        return new ServiceResult
        {
            Failures = new List<IFailureInformation>()
        };
    }
}