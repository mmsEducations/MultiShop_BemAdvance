
namespace MultiShop.Business
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        //Step3
        private readonly IMapper _mapper = mapper;

        public List<CategoryDto> GetCategories()
        {
            List<Category> categories = _categoryRepository.GetAll();
            List<CategoryDto> categoriDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoriDtos;

        }
    }
}


//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 