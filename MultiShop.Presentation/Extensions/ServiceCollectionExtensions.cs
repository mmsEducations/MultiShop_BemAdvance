using MultiShop.Business.Interfaces;
using MultiShop.Business.Interfaces.Test;
using MultiShop.Business.Services;
using MultiShop.Repository;

namespace MultiShop.Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // Servis Entegrasyonu
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, ProductsRepository>();

            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ISliderRepository, SliderRepository>();

            // Product
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Product Rating
            services.AddScoped<IProductRatingService, ProductRatingService>();
            services.AddScoped<IProductRatingRepository, ProductRatingRepository>();

            // Product Image
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();

            // Customer
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Order & Order Detail
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();


            //Test Service
            services.AddScoped<ITestService, TestService>();
        }
    }
}
