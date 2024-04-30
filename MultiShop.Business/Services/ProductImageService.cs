namespace MultiShop.Business
{
    public class ProductImageService(IProductImageRepository productImageRepository,
                                      IProductRepository productRepository,
                                      IMapper mapper)

        : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository = productImageRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;


    }
}


//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 