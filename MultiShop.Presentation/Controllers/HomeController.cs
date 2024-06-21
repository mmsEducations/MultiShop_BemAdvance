namespace MultiShop.Presentation.Controllers
{
    //Primary Constructor 
    public class HomeController(ICategoryService categoryService,
                               ISliderService sliderService,
                              IProductService productService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly ISliderService _sliderService = sliderService;
        private readonly IProductService _productService = productService;


        public IActionResult Index()
        {
            return View();
        }

    }
}

