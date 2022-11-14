using Models;
namespace DataAccessLayer;

public interface ILikeRepository
{
    public void CreateLike(int UserId, int PostId);
    public List<Like> GetPostLikes(int PostId);
    public void DeleteLike(int UserId, int PostId);
}