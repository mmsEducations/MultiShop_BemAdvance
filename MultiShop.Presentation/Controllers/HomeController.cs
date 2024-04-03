using Microsoft.AspNetCore.Mvc;
using MultiShop.Business;

namespace MultiShop.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISliderService _sliderService;
        private readonly IProductService _productService;

        public HomeController(ICategoryService categoryService,
                               ISliderService sliderService,
                              IProductService productService)
        {
            _categoryService = categoryService;
            _sliderService = sliderService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var predicate = new List<Func<CategoryDto, bool>>();
            predicate.Add(c => c.CategoryId == 1);

            //select * from Where //Sorgulanabilir 
            var categores = _categoryService.GetCategories().AsQueryable().Where(predicate[0]);

            var sliders = _sliderService.GetSliders();


            var products = _productService.GetProducts();

            //selecte * from where ? 

            //int CategoryId = 100; int ParentCategoryId = 100;
            //var predicate = new List<Expression<Func<Slider, bool>>>();

            //if (CategoryId != null)
            //{
            //    predicate.Add(x => x.Content != null);

            //}

            //if (ParentCategoryId != null)
            //{
            //    predicate.Add(x => x.ParentCategoryId != null);

            //}


            //var categories = Context.Categories.Where(x => x.IsActive == true);

            //var sliders = Context.Sliders.ToList();
            return View();
        }

    }
}

