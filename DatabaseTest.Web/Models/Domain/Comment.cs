using DatabaseTest.Web.Models.Domain.Common;

namespace DatabaseTest.Web.Models.Domain
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}