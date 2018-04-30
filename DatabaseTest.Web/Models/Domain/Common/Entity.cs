using System;

namespace DatabaseTest.Web.Models.Domain.Common
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}