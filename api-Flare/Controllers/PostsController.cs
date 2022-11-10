using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using Models;

namespace api_Flare.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostRepository postRepository;
    public PostsController(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }

    [HttpPost]
    [Route("create")]
    public void CreatePost([FromBody] Post post)
    {
        postRepository.Create(post);
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
