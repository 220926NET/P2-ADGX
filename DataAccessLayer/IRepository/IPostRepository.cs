using Models;
namespace DataAccessLayer;

public interface IPostRepository
{
    List<Post> GetAll();
    Post GetById(int id);
    void Create(NewPost entity, int userId, PostImage postImage = null);
    void Update(Post entity);
    void Delete(Post entity);
}