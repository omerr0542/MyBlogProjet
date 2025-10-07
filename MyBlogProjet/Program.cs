using Blogy.Business.Mappings;
using Blogy.Business.Services.CategoryService;
using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.BlogRepository;
using Blogy.DataAccess.Repositories.BlogTagRepository;
using Blogy.DataAccess.Repositories.CategoryRepository;
using Blogy.DataAccess.Repositories.SocialRepositories;
using Blogy.DataAccess.Repositories.TagRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddAutoMapper(typeof(CategoryMappings).Assembly); // AutoMapper'ý CategoryMappings sýnýfýnýn bulunduðu assembly üzerinden tarayarak tüm mapping profillerini yükler.
// Assembly, derleme anlamýna gelir. Yani bu kod, AutoMapper'ýn CategoryMappings sýnýfýnýn tanýmlý olduðu derlemeyi (assembly) bulup, o derleme içindeki tüm mapping profillerini otomatik olarak yüklemesini saðlar. Bu sayede, uygulama içinde baþka mapping profilleri eklenirse, bunlar da otomatik olarak tanýnýr ve kullanýlabilir hale gelir.

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogTagRepository, BlogTagRepository>();
builder.Services.AddScoped<ISocialRepository, SocialRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
