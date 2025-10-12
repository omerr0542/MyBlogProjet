using Blogy.Business.DTOs.BlogDtos;
using Blogy.Entity.Entites;

namespace Blogy.Business.Services.BlogServices;

public interface IBlogService : IGenericService<ResultBlogDto, UpdateBlogDto, CreateBlogDto>
{

}
