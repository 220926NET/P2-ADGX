using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace api_Flare.Controllers;


[Authorize]
[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{

    private readonly IProfileService _profileService;
    private readonly int _mockUserId = 4;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpPost("Photo")]
    public async Task<ActionResult<ResponseMessage<string>>> PostUserProfilePhoto(IFormFile userPhoto)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        IEnumerable<Claim> claims = identity!.Claims;
        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;


        ResponseMessage<string> postUserPhotoRes = await _profileService.uploadUserPhoto(userPhoto, id);

        return Ok(postUserPhotoRes);

    }

    [HttpGet("profileDetails")]
    public async Task<ActionResult<ResponseMessage<ProfilePage>>> GetProfileDetails()
    {
        ResponseMessage<ProfilePage> getProfilePageRes = await _profileService.GetProfileDetails(_mockUserId);

        return Ok(getProfilePageRes);

    }

    [HttpGet("profileDetails/{userId}")]
    public async Task<ActionResult<ResponseMessage<ProfilePage>>> GetProfileDetails(int userId)
    {
        ResponseMessage<ProfilePage> getProfilePageRes = await _profileService.GetProfileDetails(userId);

        return Ok(getProfilePageRes);

    }

    [HttpGet("profilePosts/{userId}")]
    public async Task<ActionResult<ResponseMessage<List<ProfilePost>>>> GetOtherUserProfileDetails(int userId)
    {
        ResponseMessage<List<ProfilePost>> getProfilePageRes = await _profileService.GetProfilePosts(userId);

        return Ok(getProfilePageRes);

    }

    [HttpGet("/profilePosts")]
    public ActionResult<ResponseMessage<ProfilePosts>> GetProfilePosts()
    {

        ResponseMessage<List<ProfilePosts>> getProfilePostsRes = new ResponseMessage<List<ProfilePosts>>();

        List<ProfilePosts> mockProfilePosts = new List<ProfilePosts>(){
            new ProfilePosts(){
                PostUrl ="https://media.4-paws.org/1/e/d/6/1ed6da75afe37d82757142dc7c6633a532f53a7d/VIER%20PFOTEN_2019-03-15_001-2886x1999-1920x1330.jpg",
                Title = "My New Puppy"
            },
            new ProfilePosts(){
                PostUrl ="https://upload.wikimedia.org/wikipedia/commons/6/6d/Good_Food_Display_-_NCI_Visuals_Online.jpg",
                Title = "This was great!"
            },
            new ProfilePosts(){
                PostUrl ="https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/0x0.jpg?format=jpg&crop=4560,2565,x790,y784,safe&width=1200https://media.4-paws.org/1/e/d/6/1ed6da75afe37d82757142dc7c6633a532f53a7d/VIER%20PFOTEN_2019-03-15_001-2886x1999-1920x1330.jpg",
                Title = "My new Car"
            },
             new ProfilePosts(){
                PostUrl ="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdz3nhXSgiCnwrsKcOUcI-5vMvhbhqROSkCA&usqp=CAU",
                Title = "My New Puppy"
            },
            new ProfilePosts(){
                PostUrl ="https://upload.wikimedia.org/wikipedia/commons/6/6d/Good_Food_Display_-_NCI_Visuals_Online.jpg",
                Title = "This was great!"
            },
            new ProfilePosts(){
                PostUrl ="https://imageio.forbes.com/specials-images/imageserve/5d35eacaf1176b0008974b54/0x0.jpg?format=jpg&crop=4560,2565,x790,y784,safe&width=1200https://media.4-paws.org/1/e/d/6/1ed6da75afe37d82757142dc7c6633a532f53a7d/VIER%20PFOTEN_2019-03-15_001-2886x1999-1920x1330.jpg",
                Title = "My new Car"
            }
        };

        getProfilePostsRes.data = mockProfilePosts;
        getProfilePostsRes.success = true;
        getProfilePostsRes.message = "Sucessfully retrieved profile posts!";

        return Ok(getProfilePostsRes);

    }

    [HttpDelete("profilePhoto")]

    public async Task<ActionResult<ResponseMessage<string>>> DeleteUserPhoto()
    {

        ResponseMessage<string> deleteUserPhotoRes = new ResponseMessage<string>();
        int mockUserId = 4;

        deleteUserPhotoRes = await _profileService.DeleteProfilePicture(mockUserId);

        return Ok(deleteUserPhotoRes);

    }

    [HttpDelete("profilePost/{postId}")]
     public async Task<ActionResult<ResponseMessage<string>>> DeleteProfilePost(int postId)
    {

        ResponseMessage<string> deleteProfilePostRes = new ResponseMessage<string>();

        deleteProfilePostRes = await _profileService.DeleteProfilePost(_mockUserId, postId);

        return Ok(deleteProfilePostRes);

    }


    [HttpPost("/hobbies")]

    public async Task<ActionResult<ResponseMessage<List<string>>>> UploadUserDetails([FromBody] ProfileHobbies hobbies)
    {
        ResponseMessage<string> uploadUserDetailsRes = await _profileService.UploadProfileHobbies(_mockUserId, hobbies);

        return Ok(uploadUserDetailsRes);
    }


    [HttpPost("/interests")]
    public async Task<ActionResult<ResponseMessage<string>>> UploadUserInterests([FromBody] ProfileInterests interests)
    {


        ResponseMessage<string> uploadUserInterestsRes = new ResponseMessage<string>();
        uploadUserInterestsRes = await _profileService.UploadProfileInterests(_mockUserId, interests);
        return Ok(uploadUserInterestsRes);


    }



    [HttpPost("/AboutMe")]

    public async Task<ActionResult<ResponseMessage<string>>> AddProfileAboutMe([FromBody] ProfileAboutMe aboutMe)
    {
        ResponseMessage<string> addProfileAboutMeRes = new ResponseMessage<string>();

        addProfileAboutMeRes = await _profileService.SetProfileAboutMe(_mockUserId, aboutMe);

        return Ok(addProfileAboutMeRes);
    }



    [HttpGet("/profile/{userId}")]
    public async Task<ActionResult<ResponseMessage<ProfilePage>>> GetUserProfileDetails(int userId)
    {

        ResponseMessage<ProfilePage> response = new ResponseMessage<ProfilePage>();
        response = await _profileService.GetProfileDetails(userId);
        return Ok(response);
    }


}
