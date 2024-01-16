

using System.ComponentModel.DataAnnotations;

namespace MyWinFormsApp.model
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string PhotoPath { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}