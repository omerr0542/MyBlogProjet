using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.BlogRepository;
using Blogy.DataAccess.Repositories.BlogTagRepository;
using Blogy.DataAccess.Repositories.CategoryRepository;
using Blogy.DataAccess.Repositories.CommentRepositories;
using Blogy.DataAccess.Repositories.SocialRepositories;
using Blogy.DataAccess.Repositories.TagRepositories;
using Blogy.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blogy.DataAccess.Extensions
{
    public static class ServiceRegistrations
    {
        // this kullanım amacı nedir?

        public static void AddRepositoriesExt(this IServiceCollection services, IConfiguration configuration)
        {
            // Burada repository'ler scoped olarak kaydediliyor. Scoped yaşam süresi, her HTTP isteği için bir örnek oluşturulmasını sağlar.
            // Burada bunların eklenme nedeni, uygulamanın ihtiyaç duyduğu veri erişim katmanını sağlamaktır.
            // Örneğin, bir blog yazısı eklemek, silmek veya güncellemek gibi işlemler için ilgili repository'ler kullanılır.
            // Bu sayede, uygulama katmanları arasında gevşek bağlılık sağlanır ve test edilebilirlik artırılır.
            // Uygulama içinde bir controller veya servis CategoryRepository'ye ihtiyaç duyduğunda, bu repository otomatik olarak enjekte edilir.
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogTagRepository, BlogTagRepository>();
            services.AddScoped<ISocialRepository, SocialRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
