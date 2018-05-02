using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseTest.Web.Models.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required and maximum length is 100 ...")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required and maximum length is 500 ...")]
        [MaxLength(500)]
        public string Content { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}