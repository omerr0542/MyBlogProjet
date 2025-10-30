﻿using Microsoft.AspNetCore.Identity;

namespace Blogy.Entity.Entites
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Title { get; set; }
        public string? ProfileImageUrl { get; set; }

        public IList<Blog> Blogs { get; set; }
        public IList<Comment> Comments { get; set; }

    }
}
