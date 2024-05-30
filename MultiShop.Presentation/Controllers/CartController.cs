namespace MultiShop.Presentation.Controllers
{
    public class CartController(IProductService productService) : Controller
    {
        private readonly IProductService _productService = productService;

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        //Todo sayı eklenecek 
        public IActionResult AddtoCart(int id, int quantity = 1)//1
        {
            var product = _productService.GetProductById(id);
            ProductCartDto productCartDto = new ProductCartDto()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                DistcountedPrice = product.DistcountedPrice,
                Quantity = quantity,
            };
            if (product != null)
            {
                Cart _cart = HttpContext.Session.GetObject<Cart>("cart");//Session bulunan cart'ı getir
                if (_cart == null)
                {
                    _cart = new Cart();//_cart objesi oluştur
                }
                _cart.AddProduct(productCartDto, 1);//Ürünü nesneye ekle
                HttpContext.Session.SetObject("cart", _cart);//nesneyi session'a ekle//Session'ı güncelliyoruz 
            }
            return RedirectToAction("Index");
        }


        public IActionResult RemoveFromCart(int id)
        {
            var product = _productService.GetProductById(id);
            ProductCartDto productCartDto = new ProductCartDto()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                DistcountedPrice = product.DistcountedPrice,
            };

            if (product != null)
            {
                Cart _cart = HttpContext.Session.GetObject<Cart>("cart");//Session bulunan cart'ı getir
                if (_cart != null)
                {
                    _cart.DeleteProduct(productCartDto);
                    HttpContext.Session.SetObject("cart", _cart);//nesneyi session'a ekle//Session'ı güncelliyoruz 
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult CartQuantityDecrease(int id)
        {
            var product = _productService.GetProductById(id);

            if (product != null)
            {
                Cart _cart = HttpContext.Session.GetObject<Cart>("cart");//Session bulunan cart'ı getir
                if (_cart != null)
                {
                    _cart.CartQuantityDecrease(id);
                    HttpContext.Session.SetObject("cart", _cart);//nesneyi session'a ekle//Session'ı güncelliyoruz 
                }
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            Cart _cart = HttpContext.Session.GetObject<Cart>("cart");//Session bulunan cart'ı al
            if (_cart == null)
            {
                _cart = new Cart();
                HttpContext.Session.SetObject("cart", _cart);//Session'a ata
            }

            return _cart;//Session cart bilgisi dönülür 
        }


        public IActionResult ClearCart()
        {
            return View();
        }
    }
}


