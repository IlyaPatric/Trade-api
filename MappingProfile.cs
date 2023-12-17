using AutoMapper;
using TradeApi.Dto;
using TradeApi.Tables;

namespace TradeApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.manufacturer, opt => opt.MapFrom(src => src.manufacturer.name))
                .ForMember(dest => dest.provider, opt => opt.MapFrom(src => src.provider.name))
                .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.category.name));

            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.manufacturerId, opt => opt.MapFrom(src => src.manufacturer))
                .ForMember(dest => dest.providerId, opt => opt.MapFrom(src => src.provider))
                .ForMember(dest => dest.categoryId, opt => opt.MapFrom(src => src.category));

            CreateMap<Manufacturer, ManufacturerDto>()
                .ForMember(dest => dest.id, opt => opt.Ignore());

            CreateMap<ManufacturerDto, Manufacturer>();

            CreateMap<Provider, ProviderDto>()
                .ForMember(dest => dest.id, opt => opt.Ignore());

            CreateMap<ProviderDto, Provider>();

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.id, opt => opt.Ignore());

            CreateMap<CategoryDto, Category>();
        }
    }
}
