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
    public bool isTextPost { get; set; }
    public DateTime DatePosted { get; set; }
    public IFormFile? Image { get; set; }
    public string? ImageUrl { get; set;}
    public string? Description {get; set;}
}