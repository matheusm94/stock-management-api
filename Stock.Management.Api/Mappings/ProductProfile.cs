using AutoMapper;
using Stock.Management.Api.Database.Entities;
using Stock.Management.Api.DTOs;

namespace Stock.Management.Api.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDto, Product>()
            .ForMember(dst => dst.Name, map => map.MapFrom(src => src.Name))
            .ForMember(dst => dst.Price, map => map.MapFrom(src => src.Price))
            .ForMember(dst => dst.Maturitydate, map => map.MapFrom(src => src.Maturitydate));
    }
}
