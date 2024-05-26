using Microsoft.EntityFrameworkCore;
using MultiShop.Business.Interfaces;
using MultiShop.Data;
using MultiShop.Repository;
using Newtonsoft.Json;

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


//4:for connection db 
//bunun set edildiði yer MultiShopDbContext içerisindeki constructor metottur.
builder.Services.AddDbContext<MultiShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MultiShopConnectionStr_Prod"));
});
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MultiShopDbContext>();

//Step2 : AutoMapper
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(SliderMappingProfile));


var app = builder.Build();


app.UseRouting(); //2

app.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{action=index}/{id?}");//2

app.UseStaticFiles();//3

//UserController/Index -> User/Index/id
//? optional

#region add dumy data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MultiShopDbContext>();
    //var deneme=context.Products.ToList();
    if (!context.Categories.Any() || !context.Sliders.Any())
    {
        // IWebHostEnvironment servisini al
        var env = services.GetRequiredService<IWebHostEnvironment>();
        string pathcategories = Path.Combine(env.WebRootPath, @"DumyData\categorieswithinclude.json");//dosya yolunu alýr
        string categories = File.ReadAllText(pathcategories);//dosyayý verisini string deðiþkene atar
        string pathSliders = Path.Combine(env.WebRootPath, @"DumyData\sliders.json");
        string sliders = File.ReadAllText(pathSliders);
        //json verilerini objelere dönüþtürür
        var categoriesObject = JsonConvert.DeserializeObject<List<Category>>(categories);
        if (categoriesObject != null)
        {
            foreach (var category in categoriesObject)
            {
                category.CategoryId = null;
                foreach (var product in category.Products)
                {
                    product.ProductID = null;
                    foreach (var productimage in product.ProductImages)
                    {
                        productimage.ProductImageId = null;
                    }
                    foreach (var productRating in product.ProductRatings)
                    {
                        productRating.ProductRatingId = null;
                    }
                }
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories ON");
            context.AddRange(categoriesObject);
            context.SaveChanges();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories OFF");
        }
        var slidersObject = JsonConvert.DeserializeObject<List<Slider>>(sliders);
        if (slidersObject != null)
        {
            foreach (var item in slidersObject)
            {
                item.Id = null;
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories ON");
            context.AddRange(slidersObject);
            context.SaveChanges();
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Categories OFF");
        }
    }
}
#endregion


app.Run();
