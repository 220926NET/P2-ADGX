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
    public PostService(IPostRepository postRepository, BlobStorage blobStorage, IProfileRepository profileRepository, VisionApi visionApi)
    {
        _visionApi = visionApi;
        _blobStorage = blobStorage;
        _repo = postRepository;
        _profileRepository = profileRepository;

    }
    public async Task<ResponseMessage<string>> CreatePost(Post userPost)
    {

        ResponseMessage<string> addUserPostRes = new ResponseMessage<string>();


        if (userPost.isTextPost)
        {
            // upload text post into databse 
            _repo.Create(userPost);
            Console.WriteLine("inside create text post");
        }
        else
        {


            // creata new image post and pass it in
            //get a hash string consisting of the image, image text and username that will be used as the imageName in the database and blob storage
            string userPostImageHash = ImageHash.GetImageHash(userPost.Image!, userPost.Text, _mockUserName);
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
                _repo.Create(userPost, imagePost);


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