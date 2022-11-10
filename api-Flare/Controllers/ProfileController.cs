using Microsoft.AspNetCore.Mvc;
using Models;

namespace api_Flare.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{

    private readonly IProfileService _profileService;
    private readonly int _mockUserId = 4;

    //  ProfilePage _mockProfilePage;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpPost("Photo")]
    public async Task<ActionResult<ResponseMessage<string>>> PostUserProfilePhoto(IFormFile userPhoto)
    {
        int mockUserId = 4;
        ResponseMessage<string> postUserPhotoRes = await _profileService.uploadUserPhoto(userPhoto, mockUserId);

        return Ok(postUserPhotoRes);

    }

    [HttpGet("profileDetails")]
    public async Task<ActionResult<ResponseMessage<ProfilePage>>> GetProfileDetails()
    {

        ResponseMessage<ProfilePage> getProfilePageRes = await _profileService.GetProfileDetails(_mockUserId);

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

    [HttpPost("/hobbies")]

    public async Task<ActionResult<ResponseMessage<List<string>>>> UploadUserDetails([FromBody] ProfileHobbies hobbies)
    {
        ResponseMessage<string> uploadUserDetailsRes = await _profileService.UploadProfileHobbies(_mockUserId, hobbies);

        return Ok(uploadUserDetailsRes);
    }



    [HttpPost("/interests")]
    public async Task<ActionResult<ResponseMessage<List<string>>>> UploadUserInterests([FromBody] ProfileInterests interests)
    {


        ResponseMessage<List<string>> uploadUserInterestsRes = new ResponseMessage<List<string>>();
        await _profileService.UploadProfileInterests(_mockUserId, interests);
        return Ok(uploadUserInterestsRes);


    }



    [HttpPost("/AboutMe")]

    public async Task<ActionResult<ResponseMessage<string>>> AddProfileAboutMe([FromBody] ProfileAboutMe aboutMe)
    {
        ResponseMessage<string> addProfileAboutMeRes = new ResponseMessage<string>();

        addProfileAboutMeRes = await _profileService.SetProfileAboutMe(_mockUserId, aboutMe);

        return Ok(addProfileAboutMeRes);
    }



}
