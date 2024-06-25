using MediatR;
using MultiShop.Business.MediatR.Queries;

namespace MultiShop.Presentation.Controllers
{
    //Primary Constructor 
    public class HomeController(ICategoryService categoryService,
                               ISliderService sliderService,
                              IProductService productService,
                                 IMediator mediator) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly ISliderService _sliderService = sliderService;
        private readonly IProductService _productService = productService;

        private readonly IMediator _mediator = mediator;


        public async Task<IActionResult> Index()
        {
            var query = new GetCategoriesQuery() { };
            var result = await _mediator.Send(query);

            return View();
        }

    }
}

