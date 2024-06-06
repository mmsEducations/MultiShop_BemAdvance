
namespace MultiShop.Business
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>()
            .ReverseMap();//Tersini yapar 
        }
    }
}
