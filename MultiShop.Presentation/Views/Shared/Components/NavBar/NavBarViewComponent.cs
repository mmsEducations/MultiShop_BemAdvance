

namespace MultiShop.Presentation.Views
{
    public class NavBarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public NavBarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            Cart _cart = HttpContext.Session.GetObject<Cart>("cart");//Session bulunan cart'ı getir
            TempData["CartItemsCount"] = _cart != null ? _cart.TotalProductCount() : 0;
            List<CategoryDto> categories = _categoryService.GetCategories();
            return View(categories);
        }
    }
}
