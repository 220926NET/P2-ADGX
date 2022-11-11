using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace api_Flare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public List<Comment> Get(int id)
        {
            return commentService.GetPostComments(id);
        }

        // POST api/<CommentsController>
        [HttpPost]
        [Route("create")]
        public void Post([FromBody] Comment comment)
        {
            commentService.CreateComment(comment);
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
