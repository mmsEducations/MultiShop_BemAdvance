using Microsoft.AspNetCore.Mvc;
using MultiShop.Business;
using System.Diagnostics.CodeAnalysis;

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
            var predicate = new List<Func<CategoryDto, bool>>();
            predicate.Add(c => c.CategoryId == 1);

            //select * from Where //Sorgulanabilir 
            var categores = _categoryService.GetCategories().AsQueryable().Where(predicate[0]);

            var sliders = _sliderService.GetSliders();

            var products = _productService.GetProducts();

            /*
            List<int> numbersbefor12 = new List<int>();
            List<int> numbers2before12 = new();
            List<int> numbersWith12 = [];
            */



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

        [Experimental("thisLineWillbeCheck")]
        public void DeleteAllUsers()
        {
            //Raw String 
            var favoriteNumber = 5;

            var query = $"""
                 select $* 
                 from Product
                 where price>{favoriteNumber}
                 order by price asc
                """;

        }

    }
}

