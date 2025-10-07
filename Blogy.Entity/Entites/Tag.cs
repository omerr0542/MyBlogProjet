using Blogy.Entity.Entites.Common;

namespace Blogy.Entity.Entites; 

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public IList<BlogTag> BlogTags { get; set; }

}
