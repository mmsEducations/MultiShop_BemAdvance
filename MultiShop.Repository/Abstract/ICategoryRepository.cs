
namespace MultiShop.Repository
{
    //ICategoryRepository   : Sadece Category Özel metodlar için kullanılır 
    //IRepository<Category> : Diğer base metodlara erişim için kullanılır
    public interface ICategoryRepository : IRepository<Category>
    {
        void GetTopThreeCategory();
    }


}
