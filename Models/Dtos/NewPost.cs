using Microsoft.AspNetCore.Http;

namespace Models;
public class NewPost
{

    public String Title { get; set; }
    public string? Text { get; set; }
    public string isTextPost { get; set; }
    public IFormFile? Image { get; set; }
}