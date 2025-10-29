using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entites;

namespace Blogy.DataAccess.Repositories.BlogRepository;

public interface IBlogRepository : IGenericRepository<Blog>
{
    Task<List<Blog>> GetBlogsWithCategoryAsync();

    Task<List<Blog>> GetLastNBlogsAsync(int n);
}
