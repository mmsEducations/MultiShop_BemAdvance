using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Presentation.Views
{
    //TopBar
    public class TopBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
