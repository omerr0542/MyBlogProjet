using Blogy.Business.Mappings;
using Blogy.Business.Services.CategoryService;
using Blogy.Business.Validators.CategoryValidators;
using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.BlogRepository;
using Blogy.DataAccess.Repositories.BlogTagRepository;
using Blogy.DataAccess.Repositories.CategoryRepository;
using Blogy.DataAccess.Repositories.SocialRepositories;
using Blogy.DataAccess.Repositories.TagRepositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using Blogy.Business.Services.BlogServices;
using System.Text.Json.Serialization;

// Dependency Injection Kay�t T�rleri
/*
 Kay�t T�r�     | Olu�um Zaman�                     | �m�r  | Payla��m Alan�             | Kullan�m �rne�i
 -----------------------------------------------------------------------------------------------
 AddTransient   | Her enjeksiyon �a�r�s�nda         | K�sa  | Her nesne i�in ayr�        | Helper / Service
 AddScoped      | Her HTTP Request ba��nda          | Orta  | Ayn� request i�inde ortak  | DbContext
 AddSingleton   | Uygulama ba��nda (ilk kullan�mda) | Uzun  | T�m uygulamada ortak       | Logger / Cache
 -----------------------------------------------------------------------------------------------

�rne�in
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IEmailSender, EmailSender>();  // her seferinde yeni instance
    services.AddScoped<IOrderRepository, OrderRepository>(); // her request'te ayn� instance
    services.AddSingleton<ILogService, LogService>(); // uygulama boyunca tek instance
}
 */

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddAutoMapper(typeof(CategoryMappings).Assembly); // AutoMapper'� CategoryMappings s�n�f�n�n bulundu�u assembly �zerinden tarayarak t�m mapping profillerini y�kler.
// Assembly, derleme anlam�na gelir. Yani bu kod, AutoMapper'�n CategoryMappings s�n�f�n�n tan�ml� oldu�u derlemeyi (assembly) bulup, o derleme i�indeki t�m mapping profillerini otomatik olarak y�klemesini sa�lar. Bu sayede, uygulama i�inde ba�ka mapping profilleri eklenirse, bunlar da otomatik olarak tan�n�r ve kullan�labilir hale gelir.

builder.Services.AddFluentValidationAutoValidation()          // FluentValidation'� MVC pipeline�a ekler
                .AddFluentValidationClientsideAdapters()       // Client-side validation (taray�c�da an�nda hata g�sterimi)
                .AddValidatorsFromAssembly(typeof(CreateCategoryValidator).Assembly); // FluentValidation k�t�phanesini kullanarak, CreateCategoryValidator s�n�f�n�n bulundu�u assembly i�indeki t�m validator s�n�flar�n� otomatik olarak bulup kaydeder.


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();

builder.Services.AddScoped<IBlogTagRepository, BlogTagRepository>();

builder.Services.AddScoped<ISocialRepository, SocialRepository>();

builder.Services.AddScoped<ITagRepository, TagRepository>();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Areas i�in route tan�m�. Areas, b�y�k uygulamalarda mod�lerlik sa�lar.
// Areas, uygulamay� farkl� b�l�mlere ay�rarak, her b�l�m�n kendi controller, view ve model setine sahip olmas�n� sa�lar.
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
