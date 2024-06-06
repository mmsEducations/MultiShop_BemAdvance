namespace MultiShop.Business
{
    public class OrderService(IOrderRepository orderRepository,
                              IOrderDetailRepository orderDetailRepository,
                                IMapper mapper
                                ) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository = orderDetailRepository;
        private readonly IMapper _mapper = mapper;

        public List<OrderDetailDto> GetOrderDetails()
        {

            List<OrderDetail> orderDetails = _orderDetailRepository.GetAll();
            List<OrderDetailDto> orderDetailsDtos = _mapper.Map<List<OrderDetailDto>>(orderDetails);
            return orderDetailsDtos;
        }

        public List<OrderDto> GetOrders()
        {
            List<Order> orders = _orderRepository.GetAll();
            List<OrderDto> ordersDtos = _mapper.Map<List<OrderDto>>(orders);
            return ordersDtos;
        }


    }
}