using Models;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public interface ICommentService
    {
        List<Comment> GetPostComments(int postId);
        void create_comment(Comment comment);
    }

    public class CommentService : ICommentService
    {
        private readonly ICommentsRepository commentRepository;

        public CommentService(ICommentsRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void create_comment(Comment comment)
        {
            commentRepository.CreateComment(comment);
        }

        public List<Comment> GetPostComments(int postId)
        {
            return commentRepository.GetPostComments(postId);
        }
    }
}
