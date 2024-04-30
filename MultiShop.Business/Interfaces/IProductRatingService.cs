namespace MultiShop.Business.Interfaces
{
    public interface IProductRatingService
    {
        List<ProductDto> GetProductWithRatings(ProductHeaderType productHeaderType);
    }

}