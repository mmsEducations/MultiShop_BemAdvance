namespace MultiShop.Business.Interfaces
{
    public interface IProductRatingService
    {
        List<ProductDto> GetProductWithRatings();
    }
}