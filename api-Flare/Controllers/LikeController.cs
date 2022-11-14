using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using DataAccessLayer;

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
    public void CreateLike([FromBody] Like like)
    {
        likeRepository.CreateLike(like.UserId, like.PostId);
    }

    [HttpDelete]
    public void DeleteLike([FromBody] Like like)
    {
        likeRepository.DeleteLike(like.UserId, like.PostId);
    }
}