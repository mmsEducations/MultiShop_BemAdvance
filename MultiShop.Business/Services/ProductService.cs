using AutoMapper;
using MultiShop.Data;
using MultiShop.Repository;

namespace MultiShop.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public List<ProductDto> GetProducts()
        {
            List<Product> categories = _productRepository.GetAll();
            List<ProductDto> categoriDtos = _mapper.Map<List<ProductDto>>(categories);
            return categoriDtos;

        }
    }
}


//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 