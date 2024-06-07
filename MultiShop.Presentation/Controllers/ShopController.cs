using MultiShop.Business.Dto;

namespace MultiShop.Presentation.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index(FilterDto filter)
        {
            return View();
        }
    }
}
