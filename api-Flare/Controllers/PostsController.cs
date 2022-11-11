using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using Models;

namespace api_Flare.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostRepository postRepository;

    private readonly IPostService _postService;

    private readonly int _mockUserId = 4;

    public PostsController(IPostRepository postRepository, IPostService postService)
    {
        _postService = postService;
        this.postRepository = postRepository;
    }

    [HttpPost]
    [Route("create")]
    public async void CreatePost([FromForm] Post post)
    {
        //postRepository.Create(post);

        System.Console.WriteLine($"post is {post.Text}");

        await _postService.CreatePost(post);
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
    [Route(("{id}/delete"))]
    public void DeletePost()
    {

    }

}
