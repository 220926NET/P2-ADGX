using Microsoft.AspNetCore.Mvc;
using Models;

namespace api_Flare.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{

    private readonly IPostService _postService;
    public PostController(IPostService postService)
    {

        _postService = postService;

    }
    [HttpPost("/uploadPost")]
    public async Task<ActionResult<ResponseMessage<string>>> uploadUserPhoto([FromForm] Post userPost)
    {

        ResponseMessage<string> uploadUserPhotoRes = new ResponseMessage<string>();

        uploadUserPhotoRes = await _postService.AddUserPost(userPost);

        return uploadUserPhotoRes;
    }

}
