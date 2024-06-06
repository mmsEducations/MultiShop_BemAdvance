namespace MultiShop.Business
{
    public interface IOrderService
    {
        List<OrderDto> GetOrders();
        List<OrderDetailDto> GetOrderDetails();
    }


}