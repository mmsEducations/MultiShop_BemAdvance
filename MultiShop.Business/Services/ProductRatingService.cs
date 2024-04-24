
using MultiShop.Business.Interfaces;

namespace MultiShop.Business
{
    public class ProductRatingService(IProductRatingRepository productRatingRepository,
                                      IProductRepository productRepository,
                                     IMapper mapper)

        : IProductRatingService
    {
        private readonly IProductRatingRepository _productRatingRepository = productRatingRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;


        public List<ProductDto> GetProductWithRatings()
        {
            List<ProductRating> productRatings = _productRatingRepository.GetAll();
            List<ProductDto> productDtos = _mapper.Map<List<ProductDto>>(_productRepository.GetAll());

            foreach (ProductDto productDto in productDtos)
            {
                var products = productRatings.Where(p => p.ProductId == productDto.ProductID).ToList();
                productDto.ProductRating = (products != null && products.Count > 0) ? Convert.ToInt32(products.Average(p => p.Rating)) : 0;

            }
            return productDtos;
        }
    }
}


//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 