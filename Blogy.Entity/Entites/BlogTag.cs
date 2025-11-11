using Blogy.Entity.Entites.Common;

namespace Blogy.Entity.Entites;

public class BlogTag : BaseEntity
{
    public int TagId{ get; set; }
    public int BlogId {get; set; }

    public virtual Tag Tag { get; set; }
    public virtual Blog Blog { get; set; }
}
