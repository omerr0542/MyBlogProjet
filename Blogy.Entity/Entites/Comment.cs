using Blogy.Entity.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Entity.Entites
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public Blog Blog { get; set; }
        public int BlogId { get; set; }
        public AppUser Writer { get; set; }
        public int WriterId { get; set; }
    }
}
