using AutoMapper;
using MultiShop.Data;

namespace MultiShop.Business
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
            .ReverseMap();//Tersini yapar 
        }
    }
}
