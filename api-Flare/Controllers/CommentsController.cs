using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Security.Claims;



namespace api_Flare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        private readonly ILogger<CommentsController> _logger; 

        public CommentsController(ICommentService commentService, ILogger<CommentsController> logger)
        {
            _logger = logger; 
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
        public Comment Post([FromBody] CommentDto commentDto)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            IEnumerable<Claim> claims = identity!.Claims;

             int id = int.Parse(identity.FindFirst(c => c.Type == ClaimTypes.Sid)!.Value);

            Comment comment = new Comment(){
                UserID = id,
                PostID = commentDto.PostId,
                Text = commentDto.Text
            }; 
            
            return commentService.create_comment(comment);
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
