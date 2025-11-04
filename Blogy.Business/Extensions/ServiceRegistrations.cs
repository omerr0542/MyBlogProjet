using Blogy.Business.Mappings;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryService;
using Blogy.Business.Services.CommentServices;
using Blogy.Business.Validators.CategoryValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blogy.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddServicesExt(this IServiceCollection services)
        {


            services.AddAutoMapper(typeof(CategoryMappings).Assembly); // AutoMapper'ı CategoryMappings sınıfının bulunduğu assembly üzerinden tarayarak tüm mapping profillerini yükler.
                                                                               // Assembly, derleme anlamına gelir. Yani bu kod, AutoMapper'ın CategoryMappings sınıfının tanımlı olduğu derlemeyi (assembly) bulup, o derleme içindeki tüm mapping profillerini otomatik olarak yüklemesini sağlar. Bu sayede, uygulama içinde başka mapping profilleri eklenirse, bunlar da otomatik olarak tanınır ve kullanılabilir hale gelir.

            services.AddFluentValidationAutoValidation()          // FluentValidation'ı MVC pipeline’a ekler
                            .AddFluentValidationClientsideAdapters()       // Client-side validation (tarayıcıda anında hata gösterimi)
                            .AddValidatorsFromAssembly(typeof(CreateCategoryValidator).Assembly); // FluentValidation kütüphanesini kullanarak, CreateCategoryValidator sınıfının bulunduğu assembly içindeki tüm validator sınıflarını otomatik olarak bulup kaydeder.

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICommentService, CommentService>();
        }
    }
}
