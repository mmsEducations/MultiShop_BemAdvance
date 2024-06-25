using MultiShop.Business.Interfaces;
using MultiShop.Repository;

namespace MultiShop.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {

            //Servis Entegrasyonu
            services.AddScoped<ICategoryService, CategoryService>();

            //Repository ntegrasyonu 
            services.AddScoped<ICategoryRepository, ProductsRepository>();

            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ISliderRepository, SliderRepository>();

            #region product
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            #endregion

            #region productRating
            services.AddScoped<IProductRatingService, ProductRatingService>();
            services.AddScoped<IProductRatingRepository, ProductRatingRepository>();
            #endregion

            #region productImage
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            #endregion


            #region customer
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            #endregion

            #region order-orderdetail
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            #endregion
        }
    }
}
