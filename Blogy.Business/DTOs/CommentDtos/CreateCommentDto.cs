namespace Blogy.Business.DTOs.CommentDtos
{
    public class CreateCommentDto
    {
        public string? Content { get; set; }
        public int BlogId { get; set; }
        public int WriterId { get; set; }
    }
}
