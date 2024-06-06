namespace MultiShop.Business
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? ShippedCost { get; set; }
        public string ShipName { get; set; }
        public int? OrderSituation { get; set; }
    }
}
