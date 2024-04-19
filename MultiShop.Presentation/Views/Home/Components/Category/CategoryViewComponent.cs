
namespace MultiShop.Presentation.Views
{
    public class CategoryViewComponent(ICategoryService categoryService) : ViewComponent
    {
        private readonly ICategoryService _categoryService = categoryService;

        public IViewComponentResult Invoke()
        {
            List<CategoryDto> categories = _categoryService.GetCategories();
            return View(categories);
        }
    }
}
