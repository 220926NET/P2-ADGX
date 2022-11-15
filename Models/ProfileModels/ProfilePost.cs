
public class ProfilePost
{
    public int PostId { get; set; }

    public string? Title { get; set; }

    public DateTime DatePosted { get; set; }

    public string? ImageUrl { get; set; }
    public string? Text { get; set; }

    public string? Description { get; set; }

    public List<string>? ImageTags { get; set; }
}