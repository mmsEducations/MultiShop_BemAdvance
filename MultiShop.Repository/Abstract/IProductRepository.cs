
namespace MultiShop.Repository
{
    //ICategoryRepository   : Sadece Category Özel metodlar için kullanılır 
    //IRepository<Category> : Diğer base metodlara erişim için kullanılır
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductById(int id);
        List<Product> GetProductsByCategoriId(int id);
        public List<Product> GetProductsByFilter(int minPrice, int maxPrice, int sorting);
    }


}
