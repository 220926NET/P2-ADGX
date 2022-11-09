using Models;
using DataAccessLayer;

public class PostService : IPostService
{

    private readonly Repository _repo;

    private readonly BlobStorage _blobStorage;
    public PostService(Repository repo, BlobStorage blobStorage)
    {
        _blobStorage = blobStorage;
        _repo = repo;
    }
    public async Task<ResponseMessage<string>> AddUserPost(Post userPost)
    {
        ResponseMessage<string> addUserPostRes = new ResponseMessage<string>();
        //Check user post to verify that a description with title is being added or
        //a image with description is being added 

        //verify that filename is of type .png and .jpg

        if (!Validator.IsFileValid(userPost.Image))
        {
            addUserPostRes.message = "Please ensure your image is of type .jpg or .png";
            addUserPostRes.success = false;
            return addUserPostRes;
        }

        if (userPost.Image != null)
        {
            string userPostImageHash = ImageHash.GetImageHash(userPost.Image, userPost.Description);

            string completeHash = userPostImageHash;

            if (!_repo.UserImageAlreadyExists(completeHash))
            {

                addUserPostRes = await _blobStorage.uploadUserPhoto(completeHash, userPost.Image, userPost.Image.FileName.Split(".")[1]);
                //upload to blob storage , retrieve url and 
                // upload to database 

            }
            else
            {
                // upload photo to blob storage
                // add photo, description, title to database 
                addUserPostRes.message = "Please ensure your post is unique and reupload";
                addUserPostRes.success = false;
            }
        }


        return addUserPostRes;


    }

}