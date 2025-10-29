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

// Dependency Injection Kayýt Türleri
/*
 Kayýt Türü     | Oluþum Zamaný                     | Ömür  | Paylaþým Alaný             | Kullaným Örneði
 -----------------------------------------------------------------------------------------------
 AddTransient   | Her enjeksiyon çaðrýsýnda         | Kýsa  | Her nesne için ayrý        | Helper / Service
 AddScoped      | Her HTTP Request baþýnda          | Orta  | Ayný request içinde ortak  | DbContext
 AddSingleton   | Uygulama baþýnda (ilk kullanýmda) | Uzun  | Tüm uygulamada ortak       | Logger / Cache
 -----------------------------------------------------------------------------------------------

Örneðin
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IEmailSender, EmailSender>();  // her seferinde yeni instance
    services.AddScoped<IOrderRepository, OrderRepository>(); // her request'te ayný instance
    services.AddSingleton<ILogService, LogService>(); // uygulama boyunca tek instance
}
 */

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddAutoMapper(typeof(CategoryMappings).Assembly); // AutoMapper'ý CategoryMappings sýnýfýnýn bulunduðu assembly üzerinden tarayarak tüm mapping profillerini yükler.
// Assembly, derleme anlamýna gelir. Yani bu kod, AutoMapper'ýn CategoryMappings sýnýfýnýn tanýmlý olduðu derlemeyi (assembly) bulup, o derleme içindeki tüm mapping profillerini otomatik olarak yüklemesini saðlar. Bu sayede, uygulama içinde baþka mapping profilleri eklenirse, bunlar da otomatik olarak tanýnýr ve kullanýlabilir hale gelir.

builder.Services.AddFluentValidationAutoValidation()          // FluentValidation'ý MVC pipeline’a ekler
                .AddFluentValidationClientsideAdapters()       // Client-side validation (tarayýcýda anýnda hata gösterimi)
                .AddValidatorsFromAssembly(typeof(CreateCategoryValidator).Assembly); // FluentValidation kütüphanesini kullanarak, CreateCategoryValidator sýnýfýnýn bulunduðu assembly içindeki tüm validator sýnýflarýný otomatik olarak bulup kaydeder.


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

// Areas için route tanýmý. Areas, büyük uygulamalarda modülerlik saðlar.
// Areas, uygulamayý farklý bölümlere ayýrarak, her bölümün kendi controller, view ve model setine sahip olmasýný saðlar.
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
