using Microsoft.AspNetCore.Mvc;
using MultiShop.Business;

namespace MultiShop.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var predicate = new List<Func<CategoryDto, bool>>();
            predicate.Add(c => c.CategoryId == 1);

            //select * from Where //Sorgulanabilir 
            var categores = _categoryService.GetCategories().AsQueryable().Where(predicate[0]);

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

