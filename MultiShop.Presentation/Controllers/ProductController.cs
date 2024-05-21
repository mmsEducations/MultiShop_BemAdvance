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
            var prodcutDtos = _productService.GetSimilarProducts(id);

            ProductMultipleResultDto productResultDto = new ProductMultipleResultDto()
            {
                DtoTye = prodcutDto,
                ProductDtos = prodcutDtos
            };

            return View(productResultDto);
        }

    }
}

