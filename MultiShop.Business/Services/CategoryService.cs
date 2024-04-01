using MultiShop.Data;
using MultiShop.Repository;

namespace MultiShop.Business
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDto> GetCategories()
        {
            //return _categoryRepository...
            List<Category> categories = _categoryRepository.GetAll();
            //List<Category> -> Auto mapper ile List<CategoryDto> 'ya dönüştürecez
            return new List<CategoryDto> { new CategoryDto() { CategoryName = "" }, new CategoryDto() { CategoryName = "" } };
        }
    }
}


//Classlar arasında bağımlılığı azltmak için kullanılması gereken yapı Abstractiondır
//Interface kullanarak bağımlılık azaltılır ve soyutlanmış olur 