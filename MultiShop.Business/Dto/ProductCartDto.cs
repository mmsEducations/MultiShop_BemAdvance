namespace MultiShop.Business
{
    public class ProductCartDto
    {
        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public decimal DistcountedPrice { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }


        public decimal ProductQuantityPrice
        {
            get
            {
                return DistcountedPrice * Quantity;
            }
        }

    }


}
