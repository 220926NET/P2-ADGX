using Models;
using Microsoft.AspNetCore.Http;
using DataAccessLayer;
public class ProfileService : IProfileService
{

    private readonly BlobStorage _blobStorage;

    private readonly Repository _repo;

    public ProfileService(BlobStorage blobStorage, Repository repo)
    {
        _blobStorage = blobStorage;
        _repo = repo;
    }

    // This method takes in user Photo and uploads it inside a blob storage container 
    // the url is then returned and saved inside the database 
    public async Task<ResponseMessage<string>> uploadUserPhoto(IFormFile userPhoto)
    {

        ResponseMessage<string> uploadUserPhotoRes = new ResponseMessage<string>();



        if (!Validator.IsFileValid(userPhoto))
        {
            uploadUserPhotoRes.message = "Please ensure your file is of type .jpg or .png";
            uploadUserPhotoRes.success = false;
            return uploadUserPhotoRes;
        };

        string fileExtension = userPhoto.FileName.Split(".")[1];


        string mockUserName = "John";

        //TODO: verify that user doesnt already have a photo set in the database 
        uploadUserPhotoRes = await _blobStorage.uploadPhoto(mockUserName, userPhoto, fileExtension);

        //TODO: retrieve url from uploadUSerPhotoRes and add it into repo

        return uploadUserPhotoRes;

    }
}