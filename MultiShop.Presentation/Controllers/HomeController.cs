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
            //HttpContext.Session.SetString("userName", "Bektaş");

            //var cart = new Cart { Id = 1, Name = "Cart1" };
            //HttpContext.Session.SetObject("cart", cart);

            //Session ile Cookie arasındaki fark : Session Server side,Cookie client side tutar 

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

