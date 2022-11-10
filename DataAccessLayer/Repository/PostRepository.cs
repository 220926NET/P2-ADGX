using Microsoft.Data.SqlClient;
using Models;
namespace DataAccessLayer;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
    public PostRepository():base("Post")
    {
    }
    protected override Post EntityRead(SqlDataReader reader)
    {
        int PostID = (int)reader["PostID"];
        int UserID = (int)reader["UserID"];
        string Title = (string)reader["Title"];
        string Text = (string)reader["Text"];
        DateTime DatePosted = (DateTime)reader["DatePosted"];

        return new Post { PostID = PostID, UserID = UserID, Title = Title, Text = Text, DatePosted = DatePosted };
    }

    public List<Post> GetAll()
    {
        string query = "EXEC get_all_posts";
        SqlCommand command = new SqlCommand(query);
        return EntityGetList(command);
    }
    public Post GetById(int id)
    {
        string query = "EXEC get_post @PostID";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.Add(new SqlParameter("@PostID", id));
        return EntityGet(command);
    }
    public void Create(Post entity)
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            connection.Open();
            string query = $"INSERT INTO {tableName} (UserID, Title, Text, ImageUrl) VALUES (@UserID, @Title, @Text, @ImageUrl)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("@UserID", entity.UserID));
            command.Parameters.AddWithValue("@Title", entity.Title);
            command.Parameters.AddWithValue("@Text", entity.Text);

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                // Add serilog logging
            }
        }
    }
    public void Update(Post entity)
    {
        /*
        string query = $"UPDATE {tableName} SET UserID=@UserID, Title=@Title, Text=@Text, ImageUrl=@ImageUrl  WHERE PostID = @postId";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.Add(new SqlParameter("@UserID", entity.UserID));
        command.Parameters.AddWithValue("@Title", entity.Title);
        command.Parameters.AddWithValue("@Text", entity.Text);
        */
        EntityNonQuery(command);
    }
    public void Delete(Post entity)
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            connection.Open();
            string query = $"DELETE FROM {tableName} WHERE PostID = @postId";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("@postId", entity.PostID));
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                // Add serilog logging
            }
        }
    }
}
