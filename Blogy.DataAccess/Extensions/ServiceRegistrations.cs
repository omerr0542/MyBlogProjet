﻿using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.BlogRepository;
using Blogy.DataAccess.Repositories.BlogTagRepository;
using Blogy.DataAccess.Repositories.CategoryRepository;
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
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogTagRepository, BlogTagRepository>();
            services.AddScoped<ISocialRepository, SocialRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

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
