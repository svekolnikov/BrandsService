using AutoMapper;
using BrandsService.DTO;
using BrandsService.Models;
using BrandsService.Requests;

namespace BrandsService.Infrastructure.AutoMapper;

public class EntitiesProfile : Profile
{
    public EntitiesProfile()
    {
        CreateMap<Brand, BrandDto>();
        CreateMap<CreateBrandRequest, Brand>();
        CreateMap<SizeDto, Size>();
    }
}