using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entites;

namespace Blogy.DataAccess.Repositories.BlogTagRepository;

public class BlogTagRepository : GenericRepository<BlogTag>, IBlogTagRepository
{
    public BlogTagRepository(AppDbContext context) : base(context)
    {
    }
}
