using Microsoft.Data.SqlClient;
using Models;
namespace DataAccessLayer;

public class LikeRepository : RepositoryBase<Like>, ILikeRepository
{
    private readonly string tableName = "Post";
    public LikeRepository() {}

    protected override Like EntityRead(SqlDataReader reader)
    {
        return new Like { 
            PostId = (int)reader["PostID"],
            UserId = (int)reader["UserID"]
        };
    }

    public void CreateLike(int UserId, int PostId)
    {
        string query = $"EXEC create_like @UserID, @PostID";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.Add(new SqlParameter("@UserID", UserId));
        command.Parameters.Add(new SqlParameter("@PostId", PostId));
        ExecuteNonQuery(command);
    }
    public List<Like> GetPostLikes(int PostId)
    {
        string query = "EXEC get_post_likes @PostID";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.Add(new SqlParameter("@PostID", PostId));
        return ExecuteGetList(command);
    }
    public void DeleteLike(int UserId, int PostId)
    {
        string query = $"EXEC delete_like @UserID, @PostID";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.Add(new SqlParameter("@UserID", UserId));
        command.Parameters.Add(new SqlParameter("@PostId", PostId));
        ExecuteNonQuery(command);
    }
}