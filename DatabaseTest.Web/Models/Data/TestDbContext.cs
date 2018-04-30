using DatabaseTest.Web.Models.Domain;
using System.Data.Entity;

namespace DatabaseTest.Web.Models.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() : base("name=TestDB")
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}