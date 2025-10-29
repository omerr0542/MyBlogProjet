using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entites;
using Microsoft.EntityFrameworkCore;

namespace Blogy.DataAccess.Repositories.CategoryRepository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Category>> GetCategoriesWithBlogsAsync()
    {
        return await _context.Categories.AsNoTracking().Include(c => c.Blogs).ToListAsync();
    }
}