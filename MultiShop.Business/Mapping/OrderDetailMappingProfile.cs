
namespace MultiShop.Business
{
    public class OrderDetailMappingProfile : Profile
    {
        public OrderDetailMappingProfile()
        {
            CreateMap<OrderDetail, OrderDetailDto>()
            .ReverseMap();//Tersini yapar 
        }
    }
}
