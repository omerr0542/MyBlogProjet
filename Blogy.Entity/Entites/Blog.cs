using Blogy.Entity.Entites.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogy.Entity.Entites;

public class Blog : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public string BlogImage1 { get; set; }
    public string BlogImage2 { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public IList<BlogTag> BlogTags { get; set; }
}
