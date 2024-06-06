
namespace MultiShop.Business
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerDto>()
            .ReverseMap();//Tersini yapar 
        }
    }
}
