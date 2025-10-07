using Blogy.Entity.Entites.Common;

namespace Blogy.Entity.Entites;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public IList<Blog> Blogs{ get; set; }
}
