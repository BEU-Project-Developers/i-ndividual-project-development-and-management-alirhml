using System.ComponentModel.DataAnnotations;

namespace MyWinFormsApp.model
{
    public class User
    {
   public int Id { get; set; }

 [Required]
 public string Username { get; set; }

 [Required]
 public string Password { get; set; }

 public virtual ICollection<Post> Posts { get; set; }
        
    }
}