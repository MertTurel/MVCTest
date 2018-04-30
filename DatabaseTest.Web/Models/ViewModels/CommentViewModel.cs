using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseTest.Web.Models.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}