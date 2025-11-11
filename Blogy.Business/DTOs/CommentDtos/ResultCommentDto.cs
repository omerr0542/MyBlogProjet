using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.Common;
using Blogy.Business.DTOs.UserDtos;

namespace Blogy.Business.DTOs.CommentDtos
{
    public class ResultCommentDto : BaseDto
    {
        public string Content { get; set; }
        public ResultBlogDto Blog { get; set; }
        public int BlogId { get; set; }
        public ResultUserDto Writer { get; set; }
        public int WriterId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
