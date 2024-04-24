namespace MultiShop.Business
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();

        List<CategoryDto> GetCategoriesWithProductCount();
    }
}