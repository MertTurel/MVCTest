using DatabaseTest.Web.Models.Domain.Common;
using System.Collections.Generic;

namespace DatabaseTest.Web.Models.Domain
{
    public class Post : Entity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public virtual ICollection<Comment> Comments { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}