using Blogy.Business.Extensions;
using Blogy.DataAccess.Extensions;
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
builder.Services.AddServicesExt();
builder.Services.AddRepositoriesExt(builder.Configuration);

builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login/Index";
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
app.UseAuthentication();
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
