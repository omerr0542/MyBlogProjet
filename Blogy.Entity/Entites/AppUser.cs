using Microsoft.AspNetCore.Identity;

namespace Blogy.Entity.Entites
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Title { get; set; }
        public string? ProfileImageUrl { get; set; }

        public virtual IList<Blog> Blogs { get; set; } // Lazy loading için virtual ekledik. Bu sayede ihtiyaç duyulduğunda yüklenir.
        public virtual IList<Comment> Comments { get; set; }

    }
}
