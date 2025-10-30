using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entites;
using Microsoft.EntityFrameworkCore;

namespace Blogy.DataAccess.Repositories.BlogRepository;

public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    public BlogRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Blog>> GetBlogsWithCategoryAsync()
    {
        return await _table.Include(b => b.Category).ToListAsync();
    }

    public async Task<List<Blog>> GetLastNBlogsAsync(int n)
    {
        return await _table.OrderByDescending(b => b.CreatedDate).Take(n).Include(b => b.Category).ToListAsync();
    }
}
