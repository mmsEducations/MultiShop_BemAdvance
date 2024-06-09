using MultiShop.Business.Dto;
using Sieve.Models;

namespace MultiShop.Business
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        ProductDto GetProductById(int id);

        List<ProductDto> GetSimilarProducts(int id);

        List<ProductDto> GetProductsByCategoriId(int id);

        List<ProductDto> GetProductsByFilter(FilterDto filter);

        List<ProductDto> GetProductsWithSieve(SieveModel sieveModel);
    }
}