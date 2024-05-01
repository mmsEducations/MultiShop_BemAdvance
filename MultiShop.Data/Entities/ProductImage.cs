using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShop.Data
{
    public class ProductImage : IImage
    {
        public int ProductImageId { get; set; }
        public string Image { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
