using Microsoft.AspNetCore.Http;

namespace Models;

public class Post
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Text { get; set; } = String.Empty;

    public IFormFile? Image { get; set; }
}