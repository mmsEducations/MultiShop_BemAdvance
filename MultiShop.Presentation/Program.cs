using Microsoft.EntityFrameworkCore;
using MultiShop.Business.Interfaces;
using MultiShop.Data;
using MultiShop.Repository;

var builder = WebApplication.CreateBuilder(args);//web uygulamasý oluþturulur 

builder.Services.AddControllersWithViews(); //1) Controller views alt yapýsýný entegre ediyoruz


//Servis Entegrasyonu
builder.Services.AddScoped<ICategoryService, CategoryService>();

//Repository ntegrasyonu 
builder.Services.AddScoped<ICategoryRepository, ProductsRepository>();

builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<ISliderRepository, SliderRepository>();

#region product
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion

#region productRating
builder.Services.AddScoped<IProductRatingService, ProductRatingService>();
builder.Services.AddScoped<IProductRatingRepository, ProductRatingRepository>();
#endregion

#region productImage
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
#endregion


#region customer
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
#endregion

#region order-orderdetail
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
#endregion


//4:for connection db 
//bunun set edildiði yer MultiShopDbContext içerisindeki constructor metottur.
builder.Services.AddDbContext<MultiShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MultiShopConnectionStr_Prod"));
});


//Step2 : AutoMapper

builder.Services.AddAutoMapper(typeof(ProductMappingProfile));
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(SliderMappingProfile));
builder.Services.AddAutoMapper(typeof(CustomerMappingProfile));
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
builder.Services.AddAutoMapper(typeof(OrderDetailMappingProfile));

builder.Services.AddSession();//Session kullanmak için eklenmelidir

var app = builder.Build();

app.UseRouting(); //2

app.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{action=Index}/{id?}");//2

app.UseStaticFiles();//3

//UserController/Index -> User/Index/id
//? optional

app.UseSession();

app.Run();
