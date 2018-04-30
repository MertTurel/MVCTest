using System;

namespace DatabaseTest.Web.Models.Domain.Common
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime LastModifiedAt { get; set; }
    }
}
