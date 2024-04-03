using MultiShop.Data.Interfaces;

namespace MultiShop.Data
{
    public class Product : BaseEntity, IOrdered
    {
        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public decimal? Price { get; set; }
        public decimal DistcountedPrice { get; set; }
        public short? StockQuantity { get; set; }
        public int? Order { get; set; }

    }
}
