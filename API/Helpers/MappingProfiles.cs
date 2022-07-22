using API.DTO;
using AutoMapper;
using Core.Models;
using Core.Models.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(p => p.ProductBrand, 
                    o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(p => p.ProductType, 
                    o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(p => p.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<UserTag, PoliciesDTO>().ReverseMap();
            CreateMap<CustomerBasketDTO, CustomerBasket>();
            CreateMap<BasketItemDTO, BasketItem>();
        }
    }
}