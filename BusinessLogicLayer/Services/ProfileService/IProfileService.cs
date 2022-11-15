using Models;
using Microsoft.AspNetCore.Http;
public interface IProfileService
{

    Task<ResponseMessage<string>> uploadUserPhoto(IFormFile userPhoto, int UserId);
    Task<ResponseMessage<ProfilePage>> GetProfileDetails(int userId);
    Task<ResponseMessage<string>> DeleteProfilePicture(int userId);
    Task<ResponseMessage<string>> UploadProfileHobbies(int userId, ProfileHobbies hobbies);
    Task<ResponseMessage<string>> UploadProfileInterests(int userId, ProfileInterests interests);
    Task<ResponseMessage<string>> SetProfileAboutMe(int userId, ProfileAboutMe aboutMe);

    Task<ResponseMessage<List<ProfilePost>>> GetProfilePosts(int userId);

    Task<ResponseMessage<string>> DeleteProfilePost(int userId, int postId); 

}