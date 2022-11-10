using Microsoft.Data.SqlClient;
using Models;
namespace DataAccessLayer;

public class PostRepository : IPostRepository
{
    private readonly string table = "";
    private Post ReadEntry(SqlDataReader reader)
    {
        int postid = (int)reader["PostId"];
        int userId = (int)reader["UserId"];
        string title = (string)reader["Title"];
        string text = (string)reader["Text"];
        string imageUrl = (string)reader["ImageUrl"];

        return new Post {PostId = postid, UserId = userId, Title = title, Text=text, ImageUrl=imageUrl};
    }

    public List<Post> GetAll()
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            connection.Open();
            string query = $"SELECT * FROM {table};";
            SqlCommand command = new SqlCommand(query, connection);
            List<Post> list = new List<Post>();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    list.Add(ReadEntry(reader));
                }
                return list;
            }
            catch
            {
                return new List<Post>();
            }
        }
    }
    public Post GetById(int id)
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            connection.Open();
            string query = $"SELECT * FROM {table} WHERE PostID = {id};";
            SqlCommand command = new SqlCommand(query, connection);
            List<Post> list = new List<Post>();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return ReadEntry(reader);
                }
                else
                {
                    return new Post();
                }
            }
            catch
            {
                return new Post();
            }
        }
    }
    public void Create(Post entity)
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            connection.Open();
            string query = $"INSERT INTO {table} (UserID, Title, Text, ImageUrl) VALUES (@UserID, @Title, @Text, @ImageUrl)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add(new SqlParameter("@UserID", entity.UserId));
            command.Parameters.AddWithValue("@Title", entity.Title);
            command.Parameters.AddWithValue("@Text", entity.Text);
            command.Parameters.AddWithValue("@ImageUrl", entity.ImageUrl);
            
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
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            connection.Open();
            string query = $"UPDATE {table} SET UserID=@UserID, Title=@Title, Text=@Text, ImageUrl=@ImageUrl  WHERE PostID = @postId";
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.Add(new SqlParameter("@UserID", entity.UserId));
            command.Parameters.AddWithValue("@Title", entity.Title);
            command.Parameters.AddWithValue("@Text", entity.Text);
            command.Parameters.AddWithValue("@ImageUrl", entity.ImageUrl);
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
    public void Delete(Post entity)
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            connection.Open();
            string query = $"DELETE FROM {table} WHERE PostID = @postId";
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.Add(new SqlParameter("@postId", entity.PostId));
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
