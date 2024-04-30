namespace MultiShop.Business
{
    public class ProductRatingDto
    {
        public int ProductRatingId { get; set; }
        public int ProductId { get; set; }
        public int? Rating { get; set; }
        public string Review { get; set; }
        public string Email { get; set; }
        public DateTime RateOrReviewDate { get; set; }
    }

}
