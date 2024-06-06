namespace MultiShop.Presentation.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            Cart _cart = HttpContext.Session.GetObject<Cart>("cart");//Session bulunan cart'ı getir
            return View(_cart);
        }


        [HttpPost]
        public IActionResult Save(CustomerDto customer)
        {
            return View();
        }
    }
}
