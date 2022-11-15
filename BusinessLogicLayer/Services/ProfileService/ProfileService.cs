using Models;
using Microsoft.AspNetCore.Http;
using DataAccessLayer;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using BusinessLogicLayer;
public class ProfileService : IProfileService
{

    private readonly BlobStorage _blobStorage;

    private readonly IProfileRepository _repo;


    private readonly ServerResponse _ServerResponse;

    public ProfileService(BlobStorage blobStorage, IProfileRepository repo, ServerResponse ServerResponse)
    {

        _blobStorage = blobStorage;
        _repo = repo;
        _ServerResponse = ServerResponse;
    }

    // This method takes in user Photo and uploads it inside a blob storage container 
    // the url is then returned and saved inside the database 
    public async Task<ResponseMessage<string>> UploadUserPhoto(IFormFile userPhoto, int userId, string name)
    {

        if (!Validator.IsFileValid(userPhoto))
        {
            return _ServerResponse.InvalidFileResponse();
        };

        if (await _repo.UserHasProfilePhoto(userId))
        {
            return _ServerResponse.UserHasProfilePhotoSet();
        }

        string fileExtension = userPhoto.FileName.Split(".")[1];

        string imageUrl = await _blobStorage.uploadPhoto(name, userPhoto, fileExtension);

        if (string.IsNullOrEmpty(imageUrl))
        {
            return _ServerResponse.IssueUploadingToBlobStorage();
        }

        string newPhotoFileName = name + "." + fileExtension;

        bool successUploadingPhoto = await _repo.UploadUserPhoto(userId, imageUrl!, newPhotoFileName);

        if (!successUploadingPhoto)
        {
            return _ServerResponse.IssueUploadingProfilePhotoToDb();
        }

        return _ServerResponse.SuccessfullyUploadedProfilePhoto();

    }

    public async Task<ResponseMessage<ProfilePage>> GetProfileDetails(int userId)
    {
        ResponseMessage<ProfilePage> getProfileDetailsRes = new ResponseMessage<ProfilePage>();

        ProfilePage profilePage = new ProfilePage()
        {
            Image = await _repo.GetProfilePhoto(userId),
            AboutMe = await _repo.GetProfileAboutMe(userId),
            Hobbies = await _repo.GetProfileHobbies(userId),
            Interests = await _repo.GetProfileInterests(userId)
        };


        getProfileDetailsRes.data = profilePage;
        getProfileDetailsRes.message = "Successfully Retrieved profile details!";
        getProfileDetailsRes.success = true;

        return getProfileDetailsRes;
    }

    public async Task<ResponseMessage<string>> DeleteProfilePicture(int userId)
    {
        string? deletedFileName = await _repo.DeleteUserPhoto(userId);

        if (deletedFileName != null)
        {
            bool deleteSuccess = await _blobStorage.deletePhotoFromStorage(deletedFileName);
            if (!deleteSuccess)
            {
                return _ServerResponse.DeletingFromBlobStorageFailure();
            }
        }
        else
        {

            return _ServerResponse.SqlError();

        }

        return _ServerResponse.DeletingFromBlobStorageSuccess();
    }

    public async Task<ResponseMessage<string>> UploadProfileHobbies(int userId, ProfileHobbies hobbies)
    {

        bool deleteUserHobbies = await _repo.DeleteUserHobbies(userId);

        if (!deleteUserHobbies)
        {
            return _ServerResponse.SqlError();
        }

        bool uploadUserHobbiesSuccess = await _repo.UploadUserHobbies(userId, hobbies);

        if (!uploadUserHobbiesSuccess)
        {
            return _ServerResponse.uploadUserHobbiesFailure();
        }
        return _ServerResponse.uploadUserHobbiesSuccess();

    }

    public async Task<ResponseMessage<string>> UploadProfileInterests(int userId, ProfileInterests interests)
    {
        bool deleteInterests = await _repo.DeleteProfileInterests(userId);

        if (!deleteInterests)
        {
            return _ServerResponse.SqlError();
        }
        else
        {
            Console.WriteLine("user id is " + userId);
            bool setInterests = await _repo.UploadProfileInterests(userId, interests);
            if (!setInterests)
            {
                return _ServerResponse.UploadProfileInterestsFailure();
            }
        }

        return _ServerResponse.UploadProfileInterestsSuccess();

    }

    public async Task<ResponseMessage<string>> SetProfileAboutMe(int userId, ProfileAboutMe aboutMe)
    {
        ResponseMessage<string> setProfileAboutMeRes = new ResponseMessage<string>();
        bool success = await _repo.DeleteProfileAboutMe(userId);
        if (!success)
        {
            return _ServerResponse.SqlError();
        }
        setProfileAboutMeRes.success = await _repo.SetProfileAboutMe(userId, aboutMe);
        setProfileAboutMeRes.message = "Succesfully set profile about me!";
        return setProfileAboutMeRes;
    }

    public async Task<ResponseMessage<List<ProfilePost>>> GetProfilePosts(int userId)
    {

        ResponseMessage<List<ProfilePost>> getProfilePostsRes = new ResponseMessage<List<ProfilePost>>();

        getProfilePostsRes.data = await _repo.GetProfilePosts(userId);

        return getProfilePostsRes;

    }

    public async Task<ResponseMessage<string>> DeleteProfilePost(int userId, int postId){

        ResponseMessage<string> getProfilePostsRes = new ResponseMessage<string>();

        bool success = await _repo.DeleteUserPost(userId, postId);

        if(success){
            return _ServerResponse.DeletingUserPostSuccess();
        }else {
            return _ServerResponse.SqlError();
        }


    }


}