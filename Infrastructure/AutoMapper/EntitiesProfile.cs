using AutoMapper;
using BrandsService.DTO;
using BrandsService.Models;

namespace BrandsService.Infrastructure.AutoMapper;

public class EntitiesProfile : Profile
{
    public EntitiesProfile()
    {
        CreateMap<Brand, BrandDto>();
    }
}