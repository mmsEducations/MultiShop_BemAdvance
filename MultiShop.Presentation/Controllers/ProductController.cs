using Sieve.Models;

namespace MultiShop.Presentation.Controllers
{
    //Primary Constructor 
    public class ProductController(ICategoryService categoryService,
                                   IProductService productService,
                                   ILogger<ProductController> logger) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;
        private readonly ILogger<ProductController> _logger = logger; // Injected ILogger


        public IActionResult Index(int id)
        {
            try
            {
                var sessionCartData = HttpContext.Session.GetObject<Cart>("cart");
                var productDto = _productService.GetProductById(id);
                var productDtos = _productService.GetSimilarProducts(id);

                ProductMultipleResultDto productResultDto = new ProductMultipleResultDto()
                {
                    DtoTye = productDto,
                    ProductDtos = productDtos
                };

                return View(productResultDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Index action.");
                throw; // Rethrow the exception to let the global exception handler manage it
            }

        }
        public IActionResult GetByCategory(int id)
        {
            try
            {
                var prodcutDtos = _productService.GetProductsByCategoriId(id);
                throw new ArgumentException("At least one participant must be exist");
                return View(prodcutDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetByCategory action with categoryId {CategoryId}.", id);
                throw; // Rethrow the exception to let the global exception handler manage it
            }
        }

        public IActionResult Search(string searchData, SieveModel sieveModel)
        {
            try
            {
                sieveModel.Filters = $"ProductName|CategoryName@=*{searchData}";
                var result = _productService.GetProductsWithSieve(sieveModel);
                ViewBag.SearchData = searchData;

                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in Search action with searchData {SearchData}.", searchData);
                throw; // Rethrow the exception to let the global exception handler manage it
            }
        }

    }
}

