using Blogy.Business.Extensions;
using Blogy.DataAccess.Extensions;
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
