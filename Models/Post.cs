using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Models;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostID { get; set; }
    public int UserID { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Text { get; set; } = String.Empty;
    public DateTime DatePosted { get; set; }
    public IFormFile? Image { get; set; }
}