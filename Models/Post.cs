using Microsoft.AspNetCore.Http;

namespace Models;
public class Post
{
    public string Description { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }
}