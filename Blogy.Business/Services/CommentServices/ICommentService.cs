using Blogy.Business.DTOs.CommentDtos;
using Blogy.Entity.Entites;

namespace Blogy.Business.Services.CommentServices;

public interface ICommentService : IGenericService<ResultCommentDto, UpdateCommentDto, CreateCommentDto>
{
}
