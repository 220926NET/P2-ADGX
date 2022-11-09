using Microsoft.Data.SqlClient;
using Models;
namespace DataAccessLayer;

public class PostRepository : IPostRepository
{
    private readonly string table = "Post";
    private Post ReadEntry(SqlDataReader reader)
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
                while (reader.Read())
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
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            connection.Open();
            string query = $"UPDATE {table} SET UserID=@UserID, Title=@Title, Text=@Text, ImageUrl=@ImageUrl  WHERE PostID = @postId";
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
    public void Delete(Post entity)
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            connection.Open();
            string query = $"DELETE FROM {table} WHERE PostID = @postId";
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
