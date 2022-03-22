using AutoMapper;
using BrandsService.DAL.Repositories.Interfaces;
using BrandsService.DTO;
using BrandsService.Models;
using BrandsService.Requests;
using BrandsService.Services.Interfaces;

namespace BrandsService.Services;

public class BrandService : IBrandsService
{
    private readonly IBrandsRepository _brandRepository;
    private readonly IAllowedSizesRepository _sizeRepository;
    private readonly IMapper _mapper;

    public BrandService(
        IBrandsRepository brandRepository, 
        IAllowedSizesRepository sizeRepository, 
        IMapper mapper)
    {
        _brandRepository = brandRepository;
        _sizeRepository = sizeRepository;
        _mapper = mapper;
    }
    
    public async Task<IServiceResult<IEnumerable<BrandDto>>> GetAllBrandsAsync()
    {
        var brandsEntities = await _brandRepository.GetAllWithSizesAsync();

        var brandsDto = _mapper.Map<List<BrandDto>>(brandsEntities); 

        return new ServiceResult<IEnumerable<BrandDto>>
        {
            IsSuccess = true,
            Data = brandsDto
        };
    }

    public async Task<IServiceResult<BrandDto>> GetBrandByIdAsync(int id)
    {
        var brandEntity = await _brandRepository.GetByIdWithSizesAsync(id);
        if (brandEntity is null)
        {
            return new ServiceResult<BrandDto>
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation {Description = "Бренд не найден"}
                }
            };
        }

        var brandDto = _mapper.Map<BrandDto>(brandEntity);

        return new ServiceResult<BrandDto>
        {
            IsSuccess = true, 
            Data = brandDto,
            Failures = new List<IFailureInformation>()
        };
    }

    public async Task<IServiceResult> CreateBrandAsync(CreateBrandRequest createBrandRequest)
    {
        if (await _brandRepository.GetByNameAsync(createBrandRequest.Name) is not null)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation{Description = $"Бренд с именем [{createBrandRequest.Name}] уже существует"}
                }
            };
        }

        var brandEntity = _mapper.Map<Brand>(createBrandRequest);
        await _brandRepository.AddAsync(brandEntity);

        return new ServiceResult
        {
            IsSuccess = true,
            Failures = new List<IFailureInformation>()
        };
    }
    
    public async Task<IServiceResult> UpdateBrandAsync(UpdateBrandRequest updateBrandRequest)
    {
        var brandEntity = await _brandRepository.GetByIdWithSizesAsync(updateBrandRequest.Id);
        if (brandEntity is null)
        {
            return new ServiceResult
                {
                    IsSuccess = false,
                    Failures = new List<IFailureInformation>
                    {
                        new FailureInformation {Description = "Бренд не найден"}
                    }
                };
        }
        
        if (await _brandRepository.GetByNameAsync(updateBrandRequest.Name) is not null)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation{Description = $"Бренд с именем [{updateBrandRequest.Name}] уже существует"}
                }
            };
        }

        _mapper.Map(updateBrandRequest, brandEntity);

        await _brandRepository.UpdateAsync(brandEntity);

        return new ServiceResult {IsSuccess = true, Failures = new List<IFailureInformation>()};
    }
    
    public async Task<IServiceResult> SoftDeleteBrandAsync(int id)
    {
        var entity = await _brandRepository.GetByIdAsync(id);
        if (entity is null)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation {Description = "Бренд не найден"}
                }
            };
        }

        await _brandRepository.SoftDeleteAsync(id);

        return new ServiceResult {IsSuccess = true, Failures = new List<IFailureInformation>()};
    }


    public async Task<IServiceResult<IEnumerable<AllowedSizeDto>>> GetAllSizesByBrandIdAsync(int id)
    {
        var brandEntity = await _brandRepository.GetByIdWithSizesAsync(id);
        if (brandEntity is null)
        {
            return new ServiceResult<IEnumerable<AllowedSizeDto>>
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation {Description = "Бренд не найден"}
                }
            };
        }

        var allowedSizeEntities = await _sizeRepository.GetAllSizesByBrandIdAsync(id);

        var allowedSizeDtos = _mapper.Map<List<AllowedSizeDto>>(allowedSizeEntities);
        return new ServiceResult<IEnumerable<AllowedSizeDto>>
        {
            IsSuccess = true,
            Data = allowedSizeDtos,
            Failures = new List<IFailureInformation>()
        };
    }

    public async Task<IServiceResult> CreateSizeAsync(int id, CreateSizeRequest createSizeRequest)
    {
        var brandEntity = await _brandRepository.GetByIdWithSizesAsync(id);
        if (brandEntity is null)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation {Description = "Бренд не найден"}
                }
            };
        }

        var sameSizeInBrand = await _sizeRepository.GetBySizeRfInBrand(createSizeRequest.Rf, id);
        if (sameSizeInBrand is not null)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation{Description = "В списке размеров бренда не может быть элементов с одинаковым размером РФ"}
                }
            };
        }

        var sizeEntity = _mapper.Map<AllowedSize>(createSizeRequest);
        sizeEntity.BrandId = id;
        await _sizeRepository.AddAsync(sizeEntity);

        return new ServiceResult
        { IsSuccess = true, Failures = new List<IFailureInformation>() };
    }

    public async Task<IServiceResult> UpdateSizeAsync(int brandId, int sizeId, UpdateSizeRequest updateSizeRequest)
    {
        var brandEntity = await _brandRepository.GetByIdWithSizesAsync(brandId);
        if (brandEntity is null)
        {
            return new ServiceResult<IEnumerable<AllowedSizeDto>>
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation {Description = "Бренд не найден"}
                }
            };
        }

        var entity = await _sizeRepository.GetByIdAsync(sizeId);
        if (entity is null)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                    {
                        new FailureInformation {Description = "Размер не найден"}
                    }
            };
        }

        _mapper.Map(updateSizeRequest, entity);
        await _sizeRepository.UpdateAsync(entity);

        return new ServiceResult { IsSuccess = true, Failures = new List<IFailureInformation>() };
    }

    public async Task<IServiceResult> UpdateSizesInBrandAsync(int brandId, UpdateSizesInBrandRequest updateSizesInBrandRequest)
    {
        var brandEntity = await _brandRepository.GetByIdWithSizesAsync(brandId);
        if (brandEntity is null)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                {
                    new FailureInformation {Description = "Бренд не найден"}
                }
            };
        }

        updateSizesInBrandRequest.AllowedSizesIds = updateSizesInBrandRequest.AllowedSizesIds.Distinct();

        var sizeEntities = new List<AllowedSize>();
        foreach (var sizeId in updateSizesInBrandRequest.AllowedSizesIds)
        {
            var entity = await _sizeRepository.GetByIdAsync(sizeId);
            if (entity is null)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Failures = new List<IFailureInformation>
                    {
                        new FailureInformation {Description = $"Размер id={sizeId} не найден"}
                    }
                };
            }

            sizeEntities.Add(entity);
        }

        brandEntity.AllowedSizes = sizeEntities;
        await _brandRepository.UpdateAsync(brandEntity);

        return new ServiceResult { IsSuccess = true, Failures = new List<IFailureInformation>() };
    }

    public async Task<IServiceResult> SoftDeleteSizeAsync(int brandId, int id)
    {
        var entity = await _sizeRepository.GetByIdAsync(id);
        if (entity is null)
        {
            return new ServiceResult
            {
                IsSuccess = false,
                Failures = new List<IFailureInformation>
                    {
                        new FailureInformation {Description = "Размер не найден"}
                    }
            };
        }

        await _sizeRepository.SoftDeleteAsync(id);

        return new ServiceResult { IsSuccess = true, Failures = new List<IFailureInformation>() };
    }
}