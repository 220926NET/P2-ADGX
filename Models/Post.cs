using Microsoft.AspNetCore.Http;

public class Post
{
    public string Description { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }
}