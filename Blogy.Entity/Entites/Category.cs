using Blogy.Entity.Entites.Common;

namespace Blogy.Entity.Entites;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public virtual IList<Blog> Blogs{ get; set; }
}
