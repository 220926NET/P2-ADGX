using Models;
namespace DataAccessLayer;

public interface IPostRepository
{
    List<Post> GetAll();
    Post GetById(int id);
    
    void Create(Post entity);
    void Update(Post entity);
    void Delete(Post entity);
}