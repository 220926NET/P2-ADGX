using Models;
public class TestProfileModels
{

    [Fact]
    public void TEST_VISION_API_MODEL()
    {
        // Given
        List<string> Tags = new List<string>(){
                "moon",
                "airplane",
                "sky"
            };
        string description = "A plane flying in front of the moon.";
        // When 
        VisionApiResponse visionApi = new VisionApiResponse()
        {
            Tags = Tags,
            Description = description
        };
        // Then

        Assert.Equal(visionApi.Tags, Tags);
        Assert.Equal(visionApi.Description, description);
    }

    [Fact]
    public void TEST_COMMENT_MODEL()
    {
        // Given
        Comment comment = new Comment()
        {
            CommentID = 1,
            UserID = 2,
            PostID = 3,
            ProfileID = 4,
            Text = "test test",
            Name = "john",
            ImageURL = "http://test.com"
        };

        // Then
        Assert.Equal(comment.CommentID, 1);
        Assert.Equal(comment.UserID, 2);
        Assert.Equal(comment.PostID, 3);
        Assert.Equal(comment.ProfileID, 4);
        Assert.Equal(comment.Text, "test test");
        Assert.Equal(comment.Name, "john");
        Assert.Equal(comment.ImageURL, "http://test.com");

    }

    [Fact]
    public void TEST_LIKE_MODEL()
    {
        // Given
        Like like = new Like()
        {
            UserId = 1,
            PostId = 2
        };

        // Then
        Assert.Equal(1, like.UserId);
        Assert.Equal(2, like.PostId);


    }

    [Fact]
    public void TEST_NEW_POST_MODEL()
    {
        // Given
        NewPost newPost = new NewPost()
        {
            Title = "test",
            Text = "test text",
            isTextPost = "true",
            Image = null
        };

        // Then
        Assert.Equal(newPost.Title, "test");
        Assert.Equal(newPost.Text, "test text");
        Assert.Equal(newPost.isTextPost, "true");
        Assert.Equal(newPost.Image, null);


    }
    [Fact]
    public void TEST_POST_MODEL()
    {

        DateTime now = DateTime.Now;
        // Given
        Post newPost = new Post()
        {
            PostID = 1,
            UserID = 2,
            Title = "test",
            Text = "test text",
            isTextPost = true,
            DatePosted = now,
            Image = null,
            ImageUrl = "test.com",
            Description = "test description"
        };

        // Then
         Assert.Equal(1, newPost.PostID);
        Assert.Equal(2, newPost.UserID);
        Assert.Equal( "test", newPost.Title);
        Assert.Equal("test text", newPost.Text);
        Assert.Equal(true, newPost.isTextPost );
        Assert.Equal(now, newPost.DatePosted );
        Assert.Equal("test.com", newPost.ImageUrl);
        Assert.Equal(null, newPost.Image);
        Assert.Equal("test description", newPost.Description);


    }

    [Fact]
    public void TEST_PROFILE_PAGE_MODEL()
    {

        DateTime now = DateTime.Now;
        // Given
        ProfilePage page = new ProfilePage("test.com", "love to program", new List<string>(){
        "running"
       }, new List<string>(){
        "programming"
       });

        // Then
        Assert.Equal(page.Image, "test.com");
        Assert.Equal(page.AboutMe, "love to program");
        Assert.Equal(page.Hobbies![0], "running");
        Assert.Equal(page.Interests![0], "programming");


    }

    [Fact]
    public void TEST_RESPONSE_MESSAGE_MODEL()
    {

        ResponseMessage<string> response = new ResponseMessage<string>();
        response.success = true;
        response.data = "data";
        response.message = "response message";

        // Then
        Assert.Equal(true, response.success );
        Assert.Equal("data", response.data );
        Assert.Equal("response message", response.message);


    }

    [Fact]
    public void TEST_POST_IMAGE_MODEL()
    {
        List<string> Tags = new List<string>(){
                "moon",
                "airplane",
                "sky"
            };
        PostImage postImage = new PostImage()
        {
            ImageUrl = "test.com",
            ImageName = "test",
            ImageDescription = "description",
            Tags = Tags
        };
        // Then
        Assert.Equal( "test.com", postImage.ImageUrl);
        Assert.Equal("test", postImage.ImageName );
        Assert.Equal("description", postImage.ImageDescription);
        Assert.Equal(Tags, postImage.Tags);


    }

    [Fact]
    public void TEST_PROFILE_POST_MODEL()
    {
        List<string> Tags = new List<string>(){
                "moon",
                "airplane",
                "sky"
            };
        DateTime now = DateTime.Now;
        ProfilePost profilePost = new ProfilePost()
        {
            PostId = 1,
            Title = null,
            DatePosted = now,
            ImageUrl = "test.com",
            Text = null,
            Description = null,
            ImageTags = Tags

        };
        // Then
        Assert.Equal(1, profilePost.PostId);
        Assert.Equal(null, profilePost.Title);
        Assert.Equal(now, profilePost.DatePosted);
        Assert.Equal("test.com", profilePost.ImageUrl);
        Assert.Equal(null, profilePost.Text );
        Assert.Equal(null, profilePost.Description);
        Assert.Equal(Tags, profilePost.ImageTags);
    }

    [Fact]
    public void TEST_USER_MODEL()
    {
        User user = new User()
        {
            UserId = 1,
            LoginId = 2,
            Username = "emmora",
            Password = "password123"
        };
        // Then
        Assert.Equal(1, user.UserId);
        Assert.Equal(2, user.LoginId);
        Assert.Equal("emmora", user.Username);
        Assert.Equal("password123", user.Password);

    }




}