namespace MultiShop.Data
{
    public class ProductImage : IImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }

    }
}
