using Models;

namespace DataAccessLayer
{
    public interface ICommentsRepository
    {
        List<Comment> GetPostComments(int postId);

        void CreateComment(Comment comment);
    }
}