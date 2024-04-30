namespace MultiShop.Presentation.Controllers
{
    //Primary Constructor 
    public class ProductController(ICategoryService categoryService,
                                   IProductService productService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;


        public IActionResult Index(int id)
        {
            var prodcutDto = _productService.GetProductById(id);

            return View(prodcutDto);
        }




    }
}

