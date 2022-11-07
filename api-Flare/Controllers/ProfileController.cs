using Microsoft.AspNetCore.Mvc;
using Models;

namespace api_Flare.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{

    private readonly IProfileService _profileService;

    ProfilePage _mockProfilePage;

    public ProfileController(IProfileService profileService)
    {
        _mockProfilePage = new ProfilePage("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRED0Wfr3ScQFESoWpiyZ1yBk1rFAj2laVCiQ&usqp=CAU", "13 time WWE champion", new List<string>(){
            "Running",
            "Weight Lifting",
            "Wood Working"
        }, new List<string>(){
            "Movies",
            "Video games"

        });
        _profileService = profileService;

    }

    [HttpPost]
    public async Task<ActionResult<ResponseMessage<string>>> PostUserProfilePhoto(IFormFile userPhoto)
    {
        //TODO: check if user already has a photo
        // if so delete it and save a new one 
        // else save the photo 

        ResponseMessage<string> postUserPhotoRes = await _profileService.uploadUserPhoto(userPhoto);

        return Ok(postUserPhotoRes);

    }

    [HttpGet]
    public ActionResult<ResponseMessage<ProfilePage>> GetProfileDetails()
    {

        ResponseMessage<ProfilePage> getProfilePageRes = new ResponseMessage<ProfilePage>();

        getProfilePageRes.data = _mockProfilePage;
        getProfilePageRes.message = "Successfully retrieved profile page details!";
        getProfilePageRes.success = true;

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

    [HttpDelete]

    public ActionResult<ResponseMessage<string>> DeleteUserPhoto()
    {

        ResponseMessage<string> deleteUserPhotoRes = new ResponseMessage<string>();



        deleteUserPhotoRes.data = null;
        deleteUserPhotoRes.message = "Successfully deleted user photo";
        deleteUserPhotoRes.success = true;

        return deleteUserPhotoRes;

    }

}
