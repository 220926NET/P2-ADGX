using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace api_Flare.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{


    private readonly IPostRepository postRepository;

    private readonly IPostService _postService;

    private readonly ILogger<PostsController> _logger; 


    public PostsController(IPostRepository postRepository, IPostService postService, ILogger<PostsController> logger)
    {

        _logger = logger; 
        _postService = postService;
        this.postRepository = postRepository;

    }

    [HttpPost, Route("create")]
    public async void CreatePost([FromForm] NewPost post)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        IEnumerable<Claim> claims = identity!.Claims;
        int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        await _postService.CreatePost(post, id, name);
    }

    [HttpGet]
    [Route(("{id}"))]
    public Post GetPost(int id)
    {
        return postRepository.GetById(id);
    }

    [HttpGet]
    public List<Post> GetAllPosts()
    {
        return postRepository.GetAll();
    }

    [HttpPut]
    [Route(("{id}/update"))]

    public Post UpdatePost([FromBody] Post post)
    {
        postRepository.Update(post);
        return post;
    }

    [HttpDelete]
    [Route(("{postId}/delete"))]
    public void DeletePost(int postId)
    {
        _logger.LogInformation("post deleted " + postId); 
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        IEnumerable<Claim> claims = identity!.Claims;
        int userId = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);
        string name = identity.FindFirst(c => c.Type == ClaimTypes.Name)!.Value;

        postRepository.Delete(userId, postId);

    }

}
