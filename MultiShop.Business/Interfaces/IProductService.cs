namespace MultiShop.Business
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        ProductDto GetProductById(int id);

        List<ProductDto> GetSimilarProducts(int id);

    }
}