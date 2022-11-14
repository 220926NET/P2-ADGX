using Microsoft.Data.SqlClient;
using Models;
namespace DataAccessLayer;

public class PostRepository : RepositoryBase<Post>, IPostRepository
{
    public static T ConvertFromDBVal<T>(object obj)
    {
        if (obj == null || obj == DBNull.Value)
        {
            return default(T); // returns the default value for the type
        }
        else
        {
            return (T)obj;
        }
    }

    private readonly string tableName = "Post";
    public PostRepository() { }
    protected override Post EntityRead(SqlDataReader reader)
    {
        return new Post
        {
            PostID = (int)reader["PostID"],
            UserID = (int)reader["UserID"],
            Title = (string)reader["Title"],
            Text = ConvertFromDBVal<string>(reader["Text"]),
            DatePosted = (DateTime)reader["DatePosted"],
            ImageUrl = ConvertFromDBVal<string>(reader["ImageUrl"]),
            Description = ConvertFromDBVal<string>(reader["Description"]),
        };
    }

    public List<Post> GetAll()
    {
        string query = "EXEC get_all_posts";
        SqlCommand command = new SqlCommand(query);
        return ExecuteGetList(command);
    }
    public Post GetById(int id)
    {
        string query = "EXEC get_post @PostID";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.Add(new SqlParameter("@PostID", id));
        return ExecuteGet(command);
    }
    public void Create(NewPost entity, int userId, PostImage postImage = null)
    {
        try
        {
            SqlConnection connection = ConnectionFactory.GetConnection();
            using (connection)
            {
                connection.Open();
                if (entity.isTextPost == "true")
                {
                    string query = $"exec create_text_post @UserId, @Text , @Title ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add(new SqlParameter("@UserID", userId));
                    command.Parameters.AddWithValue("@Title", entity.Title);
                    command.Parameters.AddWithValue("@Text", entity.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    int imageInsertId = 0;
                    string query = $"exec create_image_post @UserId, @Title , @ImageUrl , @ImageName, @ImageDescription ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Title", entity.Title);
                    command.Parameters.AddWithValue("@ImageUrl", postImage.ImageUrl);
                    command.Parameters.AddWithValue("@ImageName", postImage.ImageName);
                    command.Parameters.AddWithValue("@ImageDescription", postImage.ImageDescription);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            imageInsertId = (int)reader["ImageId"];
                        }

                        connection.Close();
                        connection.Open();

                        foreach (string tag in postImage.Tags)
                        {
                            query = $"exec add_photo_tag @Text, @ImageId";
                            command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@Text", tag);
                            command.Parameters.AddWithValue("@ImageId", imageInsertId);
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine("error creating post in db");
            Console.WriteLine(e);
            // Add serilog logging
        }
        finally
        {

        }
    }

    public void Update(Post entity)
    {
        string query = $"UPDATE {tableName} SET UserID=@UserID, Title=@Title, Text=@Text, ImageUrl=@ImageUrl  WHERE PostID = @postId";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.Add(new SqlParameter("@UserID", entity.UserID));
        command.Parameters.AddWithValue("@Title", entity.Title);
        command.Parameters.AddWithValue("@Text", entity.Text);
        ExecuteNonQuery(command);
    }
    public void Delete(Post entity)
    {
        string query = $"DELETE FROM {tableName} WHERE PostID = @postId";
        SqlCommand command = new SqlCommand(query);
        command.Parameters.Add(new SqlParameter("@postId", entity.PostID));
        ExecuteNonQuery(command);
    }
}