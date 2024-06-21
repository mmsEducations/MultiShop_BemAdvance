using Microsoft.EntityFrameworkCore;
using MultiShop.Data;
using MultiShop.Presentation.Extensions;
using MultiShop.Presentation.Middleware;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);//web uygulamas� olu�turulur 

builder.Services.AddControllersWithViews(); //1) Controller views alt yap�s�n� entegre ediyoruz


//Services And Repository Entegrations
builder.Services.AddCustomServices();


//4:for connection db 
//bunun set edildi�i yer MultiShopDbContext i�erisindeki constructor metottur.
builder.Services.AddDbContext<MultiShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MultiShopConnectionStr_Prod"));
});


//Step2 : AutoMapper
builder.Services.AddCustomAutoMapper();

//Sieve Configuration 
builder.Services.AddCustomSieveConfiguration(builder.Configuration); // Assuming 'builder' is an instance of IConfiguration


// Add logging configuration
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders(); // Clear the default providers (optional)
    logging.AddConsole(); // Add console logging
    logging.AddDebug(); // Add debug logging (optional)
    // Add other logging providers as needed (e.g., logging to a file, logging to Azure Application Insights, etc.)
});


builder.Services.AddSession();//Session kullanmak i�in eklenmelidir

//1.Yol Extension method olarak eklemek
builder.Services.AddMediatRHandlers(Assembly.GetExecutingAssembly());

//2.Yol 
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//builder.Services.AddTransient<IRequestHandler<GetProductByCategoryIdQuery, List<ProductDto>>, GetProductsByCategoryIdHandler>();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting(); //2

app.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{action=Index}/{id?}");//2

app.UseStaticFiles();//3

//UserController/Index -> User/Index/id
//? optional

app.UseSession();

app.Run();
