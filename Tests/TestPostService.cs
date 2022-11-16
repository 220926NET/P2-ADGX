using Models;
using DataAccessLayer;

public class TestPostService
{

    [Fact]
    public async Task TEST_TEXT_POST()
    {
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();
        VisionApi api = new VisionApi();

        int mockUserId = 2;
        string mockName = "emmanuel";
        var mockedProfileRepo = new Mock<IProfileRepository>();
        var mockedPostRepo = new Mock<IPostRepository>();
        var mockedBlobStorage = new Mock<IBlobStorage>();



        NewPost newPost = new NewPost()
        {

            Title = "test title",
            Text = "test text",
            isTextPost = "true",
            Image = null
        };


        mockedPostRepo.Setup(repo => repo.Create(newPost, mockUserId, null));

        PostService postService = new PostService(mockedPostRepo.Object, mockedBlobStorage.Object, mockedProfileRepo.Object, api);

        ResponseMessage<string> responseMessage = await postService.CreatePost(newPost, mockUserId, mockName);

        Assert.Equal(responseMessage.message, "Successfully added post");
        Assert.Equal(responseMessage.success, true);
    }

    [Fact]
    public async Task TEST_IMAGE_POST_FAILS()
    {
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();
        VisionApi api = new VisionApi();

        int mockUserId = 2;
        string mockName = "emmanuel";
        var mockedProfileRepo = new Mock<IProfileRepository>();
        var mockedPostRepo = new Mock<IPostRepository>();
        var mockedBlobStorage = new Mock<IBlobStorage>();

        var content = "Hello World from a Fake File";
        var fileName = "test.png";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(content);
        writer.Flush();
        stream.Position = 0;

        //create FormFile with desired data
        IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);


        NewPost newPost = new NewPost()
        {

            Title = "test title",
            Text = "test text",
            isTextPost = "false",
            Image = file
        };

        mockedPostRepo.Setup(repo => repo.Create(newPost, mockUserId, null));

        mockedBlobStorage.Setup(blobStorage => blobStorage.uploadPhoto(mockName, file, ".png")).ReturnsAsync("https://test.com");

        PostService postService = new PostService(mockedPostRepo.Object, mockedBlobStorage.Object, mockedProfileRepo.Object, api);

        ResponseMessage<string> responseMessage = await postService.CreatePost(newPost, mockUserId, mockName);

        Assert.Equal(responseMessage.message, "Unable to upload photo");

        Assert.Equal(responseMessage.success, false);
    }





}


