using Blogy.Business.DTOs.BlogDtos;
using Blogy.Entity.Entites;

namespace Blogy.Business.Services.BlogServices;

public interface IBlogService : IGenericService<ResultBlogDto, UpdateBlogDto, CreateBlogDto>
{
    Task<List<ResultBlogDto>> GetBlogsWithCategoryAsync();
    Task<List<ResultBlogDto>> GetBlogsByCategoryIdAsync(int CategoryId);
    Task<List<ResultBlogDto>> GetLastNBlogsAsync(int n);
}
