using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using Models;

namespace api_Flare.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostRepository postRepository;
    public PostController(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }

    // [HttpPost]
    // public void CreatePost([FromBody] Post post)
    // {
    //     postRepository.Create(post);
    // }

    [HttpGet("/{id}")]
    public Post GetPost(int id)
    {
        return postRepository.GetById(id);
    }

    [HttpGet()]
    public List<Post> GetAllPost()
    {
        return postRepository.GetAll();
    }

    [HttpPut()]
    public Post UpdatePost([FromBody] Post post)
    {
        postRepository.Update(post);
        return post;
    }

    [HttpDelete()]
    public void DeletePost()
    {

    }

}
