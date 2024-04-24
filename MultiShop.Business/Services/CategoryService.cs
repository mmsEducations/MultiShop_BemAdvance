namespace MultiShop.Business
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IProductRepository productRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        //Step3
        private readonly IMapper _mapper = mapper;

        private readonly IProductRepository _productRepository = productRepository;


        public List<CategoryDto> GetCategories()
        {
            List<Category> categories = _categoryRepository.GetAll();
            List<CategoryDto> categoriDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoriDtos;

        }

        public List<CategoryDto> GetCategoriesWithProductCount()
        {
            List<CategoryDto> categoriDtos = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetAll());
            List<Product> products = _productRepository.GetAll();

            foreach (CategoryDto CategoryDto in categoriDtos)
            {
                CategoryDto.ProductCount = products.Where(p => p.CategoryID == CategoryDto.CategoryId).Count();
            }
            return categoriDtos;

        }
    }
}


//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 