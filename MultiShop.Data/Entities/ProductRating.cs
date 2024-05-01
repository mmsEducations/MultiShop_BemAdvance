using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShop.Data
{
    public class ProductRating
    {
        public int ProductRatingId { get; set; }
        public int? Rating { get; set; }
        public string? Review { get; set; }
        public string? Email { get; set; }
        public DateTime? RateOrReviewDate { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
