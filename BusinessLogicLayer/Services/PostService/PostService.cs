using Models;
using DataAccessLayer;
using BusinessLogicLayer;
public class PostService : IPostService
{

    private readonly IPostRepository _repo;

    private readonly BlobStorage _blobStorage;

    private readonly ServerResponse _serverResponse = new ServerResponse();

    private readonly IProfileRepository _profileRepository;

    private readonly VisionApi _visionApi;

    private readonly string _mockUserName = "emmora3";

    private readonly int _mockUserId = 4; 
    public PostService(IPostRepository postRepository, BlobStorage blobStorage, IProfileRepository profileRepository, VisionApi visionApi)
    {
        _visionApi = visionApi;
        _blobStorage = blobStorage;
        _repo = postRepository;
        _profileRepository = profileRepository;

    }
    public async Task<ResponseMessage<string>> CreatePost(NewPost userPost)
    {

        ResponseMessage<string> addUserPostRes = new ResponseMessage<string>();

        //TODO check that posts are valid

        if (userPost.isTextPost == "true")
        {
            _repo.Create(userPost, _mockUserId);
        }
        else
        {
            // creata new image post and pass it in
            //get a hash string consisting of the image, image text and username that will be used as the imageName in the database and blob storage
            string userPostImageHash = ImageHash.GetImageHash(userPost.Image!, userPost.Title, _mockUserName);
            string imageName = userPostImageHash;
            string imageExtension = getImageExtension(userPost.Image!.FileName);

            //checks to see if a user has uploaded a image post that includes the same image and text
            try
            {
                string imageUrl = await _blobStorage.uploadPhoto(imageName, userPost.Image, imageExtension);
                if (string.IsNullOrEmpty(imageUrl))
                {
                    throw new Azure.RequestFailedException("Please upload a unique photo and text");
                }

                //upload to blob storage , retrieve url and 
                VisionApiResponse apiResponse = await _visionApi.GetTagsAndDescription(imageUrl);
                // upload to database 
                PostImage imagePost = new PostImage()
                {
                    ImageDescription = apiResponse.Description,
                    ImageUrl = imageUrl,
                    ImageName = imageName + "." + imageExtension,
                    Tags = apiResponse.Tags
                };
                _repo.Create(userPost, _mockUserId, imagePost);


            }
            catch (Azure.RequestFailedException e)
            {
                Console.WriteLine(e.Message);
            }






        }

        return addUserPostRes;

    }




    public string getImageExtension(string fileName)
    {
        return fileName.Split(".")[1];
    }



}