namespace MultiShop.Business
{
    public class ProductService(IProductRepository productRepository,
                                IProductRatingRepository productRatingRepository,
                                IProductImageRepository productImageRepository,
                                IMapper mapper
                                ) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IProductRatingRepository _productRatingRepository = productRatingRepository;
        private readonly IProductImageRepository _productImageRepository = productImageRepository;
        private readonly IMapper _mapper = mapper;

        public ProductDto GetProductById(int id)
        {
            Product product = _productRepository.Get(id);
            List<ProductRating> productRatings = _productRatingRepository.GetAll().Where(pr => pr.ProductId == product.ProductID).ToList();
            ProductDto productDto = _mapper.Map<ProductDto>(product);

            productDto.ProductRating = (product != null) ? Convert.ToInt32(productRatings.Average(p => p.Rating)) : 0;
            productDto.ProductRatings = productRatings;
            productDto.ProductImages = _productImageRepository.GetAll().Where(pImage => pImage.ProductId == id).ToList();

            return productDto;
        }

        public List<ProductDto> GetProducts()
        {
            List<Product> products = _productRepository.GetAll();
            List<ProductDto> categoriDtos = _mapper.Map<List<ProductDto>>(products);
            return categoriDtos;

        }


    }
}


//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 