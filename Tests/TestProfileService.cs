using Models;
using BusinessLogicLayer;
public class TestProfileService
{
    [Fact]
    public async Task TEST_RETURNS_INVALID_FILE_RESPONSE()
    {
        //Setup mock file using a memory stream
        var content = "Hello World from a Fake File";
        var fileName = "test.pdf";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(content);
        writer.Flush();
        stream.Position = 0;

        //create FormFile with desired data
        IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        int mockUserId = 2;
        string mockName = "test";
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();

        mockedRepository.Setup(repo => repo.UserHasProfilePhoto(mockUserId)).ReturnsAsync(true);

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);

        ResponseMessage<string> responseMessage = await profileService.UploadUserPhoto(file, mockUserId, mockName);

        Assert.Equal(serverResponses.InvalidFileResponse().message, responseMessage.message);

    }


    [Fact]
    public async Task TEST_USER_HAS_PROFILE_PHOTO_SET()
    {

        var content = "Hello World from a Fake File";
        var fileName = "test.png";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(content);
        writer.Flush();
        stream.Position = 0;

        //create FormFile with desired data
        IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        int mockUserId = 2;
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();
        string mockName = "test";

        mockedRepository.Setup(repo => repo.UserHasProfilePhoto(mockUserId)).ReturnsAsync(true);

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);

        ResponseMessage<string> responseMessage = await profileService.UploadUserPhoto(file, mockUserId, mockName);

        Assert.Equal(serverResponses.UserHasProfilePhotoSet().message, responseMessage.message);
    }

    [Fact]

    public async Task TEST_GET_PROFILE_DETAILS()
    {
        int mockUserId = 2;
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        ResponseMessage<ProfilePage> mockResponse = new ResponseMessage<ProfilePage>();

        ResponseMessage<ProfilePage> response = new ResponseMessage<ProfilePage>();

        ProfilePage mockPage = new ProfilePage()
        {
            Image = "https://mockurl.com",
            AboutMe = await GetProfileAboutMe(),
            Hobbies = await GetProfileHobbies(),
            Interests = await GetProfileInterests(),

        };

        response.data = mockPage;
        response.message = "Successfully Retrieved profile details!";
        response.success = true;

        mockedRepository.Setup(repo => repo.GetProfilePhoto(mockUserId)).ReturnsAsync(mockPage.Image);
        mockedRepository.Setup(repo => repo.GetProfileAboutMe(mockUserId)).Returns(GetProfileAboutMe());
        mockedRepository.Setup(repo => repo.GetProfileHobbies(mockUserId)).Returns(GetProfileHobbies());
        mockedRepository.Setup(repo => repo.GetProfileInterests(mockUserId)).Returns(GetProfileInterests());

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);
        mockResponse = await profileService.GetProfileDetails(mockUserId);

        Assert.Equal(response.success, mockResponse.success);
        Assert.Equal(response.message, mockResponse.message);
        Assert.Equal(response.data.Image, mockResponse.data.Image);
        Assert.Equal(response.data.AboutMe, mockResponse.data.AboutMe);
        Assert.Equal(response.data.Hobbies, mockResponse.data.Hobbies);
        Assert.Equal(response.data.Interests, mockResponse.data.Interests);

    }
    [Fact]

    public async Task TEST_DELETE_PROFILE_PICTURE_FAILURE()
    {
        int mockUserId = 2;
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        ResponseMessage<string> mockResponse = new ResponseMessage<string>();


        mockedRepository.Setup(repo => repo.DeleteUserPhoto(mockUserId)).Returns(GetProfileImageUrlNull());

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);

        mockResponse = await profileService.DeleteProfilePicture(mockUserId);

        Assert.Equal(mockResponse.message, serverResponses.SqlError().message);

    }


    [Fact]
    public async Task TEST_UPLOAD_PROFILE_HOBBIES_SUCCESS()
    {
        int mockUserId = 2;
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        ResponseMessage<string> mockResponse = new ResponseMessage<string>();

        ProfileHobbies mockHobbies = new ProfileHobbies()
        {
            Hobbies = new List<string>(){
                "runninng"
            }
        };




        mockedRepository.Setup(repo => repo.DeleteUserHobbies(mockUserId)).ReturnsAsync(true);
        mockedRepository.Setup(repo => repo.UploadUserHobbies(mockUserId, mockHobbies)).ReturnsAsync(true);

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);

        mockResponse = await profileService.UploadProfileHobbies(mockUserId, mockHobbies);

        Assert.Equal(mockResponse.message, serverResponses.uploadUserHobbiesSuccess().message);

    }

    [Fact]

    public async Task TEST_UPLOAD_PROFILE_HOBBIES_FAILURE()
    {
        int mockUserId = 2;
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        ResponseMessage<string> mockResponse = new ResponseMessage<string>();

        ProfileHobbies mockHobbies = new ProfileHobbies()
        {
            Hobbies = new List<string>(){
                "runninng"
            }
        };

        mockedRepository.Setup(repo => repo.DeleteUserHobbies(mockUserId)).ReturnsAsync(false);
        mockedRepository.Setup(repo => repo.UploadUserHobbies(mockUserId, mockHobbies)).ReturnsAsync(true);

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);

        mockResponse = await profileService.UploadProfileHobbies(mockUserId, mockHobbies);

        Assert.Equal(mockResponse.message, serverResponses.SqlError().message);

    }

    [Fact]
    public async Task TEST_UPLOAD_PROFILE_INTERESTS_SUCCESS()
    {
        int mockUserId = 2;
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        ResponseMessage<string> mockResponse = new ResponseMessage<string>();

        ProfileInterests mockInterests = new ProfileInterests()
        {
            Interests = new List<string>(){
                "watching movies"
            }
        };


        mockedRepository.Setup(repo => repo.DeleteProfileInterests(mockUserId)).ReturnsAsync(true);
        mockedRepository.Setup(repo => repo.UploadProfileInterests(mockUserId, mockInterests)).ReturnsAsync(true);

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);

        mockResponse = await profileService.UploadProfileInterests(mockUserId, mockInterests);

        Assert.Equal(mockResponse.message, serverResponses.UploadProfileInterestsSuccess().message);

    }


    [Fact]
    public async Task TEST_UPLOAD_PROFILE_INTERESTS_FAILURE()
    {
        int mockUserId = 2;
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        ResponseMessage<string> mockResponse = new ResponseMessage<string>();

        ProfileInterests mockInterests = new ProfileInterests()
        {
            Interests = new List<string>(){
                "watching movies"
            }
        };


        mockedRepository.Setup(repo => repo.DeleteProfileInterests(mockUserId)).ReturnsAsync(false);
        mockedRepository.Setup(repo => repo.UploadProfileInterests(mockUserId, mockInterests)).ReturnsAsync(true);

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);

        mockResponse = await profileService.UploadProfileInterests(mockUserId, mockInterests);

        Assert.Equal(mockResponse.message, serverResponses.SqlError().message);

    }

    [Fact]
    public async Task TEST_SET_PROFILE_ABOUT_ME_SUCCESS()
    {
        int mockUserId = 2;
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        ResponseMessage<string> mockResponse = new ResponseMessage<string>();

        ProfileAboutMe mockAboutMe = new ProfileAboutMe()
        { AboutMe = "I love traveling and eating food!" };


        mockedRepository.Setup(repo => repo.DeleteProfileAboutMe(mockUserId)).ReturnsAsync(true);
        mockedRepository.Setup(repo => repo.SetProfileAboutMe(mockUserId, mockAboutMe)).ReturnsAsync(true);

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);

        mockResponse = await profileService.SetProfileAboutMe(mockUserId, mockAboutMe);

        Assert.Equal(mockResponse.message, "Succesfully set profile about me!");
        Assert.Equal(mockResponse.success, true);
        Assert.Equal(mockResponse.data, null);

    }

    [Fact]
    public async Task TEST_SET_PROFILE_ABOUT_ME_FAILURE()
    {
        int mockUserId = 2;
        var mockedRepository = new Mock<IProfileRepository>();
        var mockedStorage = new Mock<BlobStorage>();
        BlobStorage blobStorage = new BlobStorage();
        ServerResponse serverResponses = new ServerResponse();

        ResponseMessage<string> mockResponse = new ResponseMessage<string>();

        ProfileAboutMe mockAboutMe = new ProfileAboutMe()
        { AboutMe = "I love traveling and eating food!" };


        mockedRepository.Setup(repo => repo.DeleteProfileAboutMe(mockUserId)).ReturnsAsync(false);
        mockedRepository.Setup(repo => repo.SetProfileAboutMe(mockUserId, mockAboutMe)).ReturnsAsync(true);

        ProfileService profileService = new ProfileService(blobStorage, mockedRepository.Object, serverResponses);

        mockResponse = await profileService.SetProfileAboutMe(mockUserId, mockAboutMe);

        Assert.Equal(mockResponse.message, serverResponses.SqlError().message);
    }

  
  

   
       // return "https://mockurl.com";
    
    public async Task<string?> GetProfileImageUrlNull()
    {
        string? url = null;

        return url;
    }

    public async Task<string> GetProfileAboutMe()
    {

        return "I love to travel and eat";

    }


    public async Task<List<string>> GetProfileHobbies()
    {

        return new List<string>(){
            "running",
            "programming",
            "working out"
        };
    }

    public async Task<List<string>> GetProfileInterests()
    {

        return new List<string>(){
            "watching movies",
            "traveling",
            "trying new food"
        };
    }



}