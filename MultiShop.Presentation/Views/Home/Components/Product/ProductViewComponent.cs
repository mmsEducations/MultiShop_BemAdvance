

namespace MultiShop.Presentation.Views
{
    public class ProductViewComponent(IProductService productService) : ViewComponent
    {
        private readonly IProductService _productService = productService;

        public IViewComponentResult Invoke()
        {
            List<ProductDto> products = _productService.GetProducts();
            return View(products);
        }
    }
}
