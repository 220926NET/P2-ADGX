using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using DataAccessLayer;
using System.Security.Claims;

namespace api_Flare.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly ILikeRepository likeRepository;
    public LikeController(ILikeRepository likeRepository)
    {
        this.likeRepository = likeRepository;
    }

    [HttpGet("{postId}")]
    public List<Like> GetPostLikes(int postId)
    {
        return likeRepository.GetPostLikes(postId);
    }

    [HttpPost]
    public void CreateLike([FromBody] int postId)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity!.Claims;
            int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
            likeRepository.CreateLike(id, postId);
        }
        catch(Exception exception)
        {
            // log error
        }
    }

    [HttpDelete]
    public void DeleteLike([FromBody] int postId)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity!.Claims;
            int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
            likeRepository.DeleteLike(id, postId);
        }
        catch(Exception exception)
        {
            // log error
        }
    }
}