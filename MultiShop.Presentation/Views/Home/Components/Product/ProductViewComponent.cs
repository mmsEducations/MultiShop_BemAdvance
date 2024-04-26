

using MultiShop.Business.Interfaces;

namespace MultiShop.Presentation.Views
{
    public class ProductViewComponent(IProductRatingService productRatingService) : ViewComponent
    {
        private readonly IProductRatingService _productService = productRatingService;

        public IViewComponentResult Invoke(ProductHeaderType ProductHeaderType)
        {
            List<ProductDto> products = _productService.GetProductWithRatings(ProductHeaderType);
            return View(products);
        }
    }
}
