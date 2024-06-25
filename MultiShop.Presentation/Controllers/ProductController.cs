using Sieve.Models;

namespace MultiShop.Presentation.Controllers
{
    //Primary Constructor 
    public class ProductController(ICategoryService categoryService,
                                   IProductService productService


                                   ) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;


        public IActionResult Index(int id)
        {

            //var sessionValue = HttpContext.Session.GetString("userName");
            var sessionCartData = HttpContext.Session.GetObject<Cart>("cart");

            var prodcutDto = _productService.GetProductById(id);
            var prodcutDtos = _productService.GetSimilarProducts(id);

            ProductMultipleResultDto productResultDto = new ProductMultipleResultDto()
            {
                DtoTye = prodcutDto,
                ProductDtos = prodcutDtos
            };

            return View(productResultDto);
        }

        [HttpGet]
        public IActionResult GetByCategory(int id)
        {
            var prodcutDtos = _productService.GetProductsByCategoriId(id);
            return View(prodcutDtos);
        }

        [HttpGet]
        public IActionResult Search(string searchData, SieveModel sieveModel)
        {
            sieveModel.Filters = $"ProductName|CategoryName@=*{searchData}";
            var result = _productService.GetProductsWithSieve(sieveModel);
            ViewBag.SearchData = searchData;


            return View(result);
        }

    }
}

