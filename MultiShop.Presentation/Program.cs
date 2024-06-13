using Microsoft.EntityFrameworkCore;
using MultiShop.Data;
using MultiShop.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);//web uygulamasý oluþturulur 

builder.Services.AddControllersWithViews(); //1) Controller views alt yapýsýný entegre ediyoruz


//Services And Repository Entegrations
builder.Services.AddCustomServices();


//4:for connection db 
//bunun set edildiði yer MultiShopDbContext içerisindeki constructor metottur.
builder.Services.AddDbContext<MultiShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MultiShopConnectionStr_Prod"));
});


//Step2 : AutoMapper
builder.Services.AddCustomAutoMapper();

//Sieve Configuration 
builder.Services.AddCustomSieveConfiguration(builder.Configuration); // Assuming 'builder' is an instance of IConfiguration


builder.Services.AddSession();//Session kullanmak için eklenmelidir

var app = builder.Build();

app.UseRouting(); //2

app.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{action=Index}/{id?}");//2

app.UseStaticFiles();//3

//UserController/Index -> User/Index/id
//? optional

app.UseSession();

app.Run();
