using Models;

namespace DataAccessLayer;
public interface IProfileRepository
{

    Task<bool> UploadUserPhoto(int userId, string imageUrl, string imageFileName);

    Task<bool> UserHasProfilePhoto(int userId);

    Task<string?> GetProfilePhoto(int userId);

    Task<string?> DeleteUserPhoto(int userId);

    Task<bool> UploadUserHobbies(int userId, ProfileHobbies hobbies);

    Task<List<string>> GetProfileHobbies(int userId);

    Task<bool> DeleteUserHobbies(int userId);

    Task<bool> UploadProfileInterests(int userId, ProfileInterests interests);

    Task<List<string>> GetProfileInterests(int userId);
    Task<bool> DeleteProfileInterests(int userId);
    Task<bool> SetProfileAboutMe(int userId, ProfileAboutMe aboutMe);

    Task<string> GetProfileAboutMe(int userId);

    Task<bool> DeleteProfileAboutMe(int userId);

    Task<bool> UserImagePostAlreadyExists(string imageName);

    Task<List<ProfilePost>> GetProfilePosts(int userId);

    Task<bool> DeleteUserPost(int userId, int postId);
}