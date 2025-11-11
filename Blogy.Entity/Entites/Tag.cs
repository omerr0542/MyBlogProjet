using Blogy.Entity.Entites.Common;

namespace Blogy.Entity.Entites; 

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public virtual IList<BlogTag> BlogTags { get; set; }

}
