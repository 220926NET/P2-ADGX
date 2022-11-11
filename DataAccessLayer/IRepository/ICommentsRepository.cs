using Models;

namespace DataAccessLayer
{
    public interface ICommentsRepository
    {
        List<Comment> GetPostComments(int postId);
        Comment CreateComment(Comment comment);
    }
}