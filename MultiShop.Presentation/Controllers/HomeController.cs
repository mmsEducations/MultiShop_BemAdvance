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
            var product = _productService.GetProductById(1);
            var products = _productService.GetProducts();


            var predicate = new List<Func<CategoryDto, bool>>();
            predicate.Add(c => c.CategoryId == 1);

            //select * from Where //Sorgulanabilir 
            var categores = _categoryService.GetCategories().AsQueryable().Where(predicate[0]);

            //var sliders = _sliderService.GetSliders();


            return View();
        }

    }
}

