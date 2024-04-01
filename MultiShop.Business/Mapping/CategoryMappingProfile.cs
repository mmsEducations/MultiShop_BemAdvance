using AutoMapper;
using MultiShop.Data;

namespace MultiShop.Business
{
    //Step1
    public class CategoryMappingProfile : Profile
    {
        //Kaynak ile hedef arasındaki dönüşüm işlemi yapılır 
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>()
            .ForMember(destination => destination.CatIdAndName,
                       optionSource => optionSource.MapFrom(source =>
                                                            string.Concat(source.CategoryId, " ", source.CategoryName)))
            .ForMember(destination => destination.ParentCategoryIdAndName,
                       optionSource => optionSource.MapFrom(source =>
                                                            string.Concat(source.ParentCategoryId, " ", source.CategoryName)))

            .ReverseMap();

        }
    }
}
// CreateMap<Source,Destination>
//.ForMember(dest => HangiAlana,Neyin set edileceğini yazıorum )