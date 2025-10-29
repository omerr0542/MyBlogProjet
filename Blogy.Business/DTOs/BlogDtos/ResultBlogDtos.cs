using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Business.DTOs.Common;

namespace Blogy.Business.DTOs.BlogDtos;

public class ResultBlogDto : BaseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public string BlogImage1 { get; set; }
    public string BlogImage2 { get; set; }
    public int CategoryId { get; set; }
    public ResultCategoryDto? Category { get; set; }
    public DateTime CreatedDate { get; set; }
}
