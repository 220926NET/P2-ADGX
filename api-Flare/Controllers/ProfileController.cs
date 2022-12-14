using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace api_Flare.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{

    private readonly IProfileService _profileService;

    private readonly ILogger<IProfileService> _logger;
    public ProfileController(IProfileService profileService, ILogger<IProfileService> logger)
    {
        _logger = logger;
        _profileService = profileService;
    }

    [HttpPost]
    [Route("Photo")]
    public async Task<ActionResult<ResponseMessage<string>>> PostUserProfilePhoto(IFormFile userPhoto)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        IEnumerable<Claim> claims = identity!.Claims;
        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        ResponseMessage<string> postUserPhotoRes = await _profileService.UploadUserPhoto(userPhoto, id, name);

        return Ok(postUserPhotoRes);

    }

    [HttpGet]
    [Route("profileDetails")]
    public async Task<ActionResult<ResponseMessage<ProfilePage>>> GetProfileDetails()
    {

        var identity = HttpContext.User.Identity as ClaimsIdentity;

        IEnumerable<Claim> claims = identity!.Claims;

        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        ResponseMessage<ProfilePage> getProfilePageRes = await _profileService.GetProfileDetails(id);

        return Ok(getProfilePageRes);

    }

    [HttpGet]
    [Route("profileDetails/{userId}")]
    public async Task<ActionResult<ResponseMessage<ProfilePage>>> GetProfileDetails(int userId)
    {
        ResponseMessage<ProfilePage> getProfilePageRes = await _profileService.GetProfileDetails(userId);

        return Ok(getProfilePageRes);

    }

    [HttpGet]
    [Route("profilePosts/{userId}")]
    public async Task<ActionResult<ResponseMessage<List<ProfilePost>>>> GetOtherUserProfileDetails(int userId)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        
        IEnumerable<Claim> claims = identity!.Claims;

        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        ResponseMessage<List<ProfilePost>> getProfilePageRes = await _profileService.GetProfilePosts(userId);

        return Ok(getProfilePageRes);

    }

    [HttpGet]
    [Route("profilePosts")]
    public async Task<ActionResult<ResponseMessage<List<ProfilePost>>>> GetProfilePosts(int userId)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        IEnumerable<Claim> claims = identity!.Claims;

        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        ResponseMessage<List<ProfilePost>> getProfilePageRes = await _profileService.GetProfilePosts(id);

        return Ok(getProfilePageRes);

    }



    [HttpDelete]
    [Route("profilePhoto")]

    public async Task<ActionResult<ResponseMessage<string>>> DeleteUserPhoto()
    {

        ResponseMessage<string> deleteUserPhotoRes = new ResponseMessage<string>();

        var identity = HttpContext.User.Identity as ClaimsIdentity;

        IEnumerable<Claim> claims = identity!.Claims;

        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        ResponseMessage<List<ProfilePost>> getProfilePageRes = await _profileService.GetProfilePosts(id);

        deleteUserPhotoRes = await _profileService.DeleteProfilePicture(id);

        return Ok(deleteUserPhotoRes);

    }


    [HttpDelete]
    [Route("profilePost/{postId}")]
    public async Task<ActionResult<ResponseMessage<string>>> DeleteProfilePost(int postId)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        IEnumerable<Claim> claims = identity!.Claims;

        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        ResponseMessage<List<ProfilePost>> getProfilePageRes = await _profileService.GetProfilePosts(id);
        ResponseMessage<string> deleteProfilePostRes = new ResponseMessage<string>();

        deleteProfilePostRes = await _profileService.DeleteProfilePost(id, postId);

        return Ok(deleteProfilePostRes);

    }


    [HttpPost]
    [Route("hobbies")]

    public async Task<ActionResult<ResponseMessage<List<string>>>> UploadUserDetails([FromBody] ProfileHobbies hobbies)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        IEnumerable<Claim> claims = identity!.Claims;

        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        ResponseMessage<List<ProfilePost>> getProfilePageRes = await _profileService.GetProfilePosts(id);
        ResponseMessage<string> uploadUserDetailsRes = await _profileService.UploadProfileHobbies(id, hobbies);

        return Ok(uploadUserDetailsRes);
    }


    [HttpPost]
    [Route("interests")]
    public async Task<ActionResult<ResponseMessage<string>>> UploadUserInterests([FromBody] ProfileInterests interests)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        IEnumerable<Claim> claims = identity!.Claims;

        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        ResponseMessage<List<ProfilePost>> getProfilePageRes = await _profileService.GetProfilePosts(id);
        ResponseMessage<string> uploadUserInterestsRes = new ResponseMessage<string>();

        uploadUserInterestsRes = await _profileService.UploadProfileInterests(id, interests);

        return Ok(uploadUserInterestsRes);
       

    }



    [HttpPost]
    [Route("AboutMe")]

    public async Task<ActionResult<ResponseMessage<string>>> AddProfileAboutMe([FromBody] ProfileAboutMe aboutMe)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        IEnumerable<Claim> claims = identity!.Claims;
        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;
        ResponseMessage<List<ProfilePost>> getProfilePageRes = await _profileService.GetProfilePosts(id);
        ResponseMessage<string> addProfileAboutMeRes = new ResponseMessage<string>();

        addProfileAboutMeRes = await _profileService.SetProfileAboutMe(id, aboutMe);

        return Ok(addProfileAboutMeRes);
    }



    [HttpGet]
    [Route("profile/{userId}")]
    public async Task<ActionResult<ResponseMessage<ProfilePage>>> GetUserProfileDetails(int userId)
    {

        ResponseMessage<List<ProfilePost>> getProfilePageRes = await _profileService.GetProfilePosts(userId);
        ResponseMessage<ProfilePage> response = new ResponseMessage<ProfilePage>();
        response = await _profileService.GetProfileDetails(userId);

        return Ok(response);
    }


}
