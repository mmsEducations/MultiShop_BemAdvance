namespace MultiShop.Presentation
{
    public class Cart
    {
        List<CartItem> _CartItems = new List<CartItem>();

        public List<CartItem> CartItems
        {
            get
            {
                return _CartItems;
            }
        }


        //Listeye eleman ekliyoruz veya listenin içerisindeki miktarı değiştiriyoruz 
        public void AddProduct(ProductCartDto product, int quantity)
        {
            //Bir ürün eklendiğinde 2 farklı durum vardır aynı üründe miktar artar farklo üründe ürün ve miktar tanımı yapılır 

            var productItem = _CartItems.FirstOrDefault(c => c.Product.ProductID == product.ProductID);
            if (productItem == null)
            {
                _CartItems.Add(new CartItem() { Product = product });
            }
            else
            {
                productItem.Product.Quantity += quantity;
            }
        }



        public void CartQuantityDecrease(int id)
        {
            var productItem = _CartItems.FirstOrDefault(c => c.Product.ProductID == id);

            productItem.Product.Quantity--;
        }
        public void DeleteProduct(ProductCartDto product)
        {
            _CartItems.RemoveAll(ci => ci.Product.ProductID == product.ProductID);
        }

        public decimal Total()
        {
            return _CartItems.Sum(c => c.Product.DistcountedPrice * c.Product.Quantity);
        }

        public int TotalProductCount()
        {
            return _CartItems.Sum(c => c.Product.Quantity);
        }

        public void Clear()
        {
            _CartItems.Clear();
        }


    }

    public class CartItem
    {
        public ProductCartDto Product { get; set; }
        //public int Quantity { get; set; }
    }
}
