//handles looking up stuff in database
using Microsoft.Data.SqlClient;
using Models;

namespace DataAccessLayer
{
    public class CommentsRepository : ICommentsRepository
    {
        SqlConnection connection;
        public CommentsRepository()
        {
            connection = SqlConnectionFactory.GetConnection();
        }

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


        public Comment CreateComment(Comment comment)
        {
            try
            {
                connection.Open();
                string query = "exec create_comment @UserId, @PostId, @Text";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserId", comment.UserID);
                cmd.Parameters.AddWithValue("@PostId", comment.PostID);
                cmd.Parameters.AddWithValue("@Text", comment.Text);
                comment.CommentID = (int)cmd.ExecuteScalar();
                cmd.Dispose();
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return comment;
        }

        public List<Comment> GetPostComments(int postId)
        {
            List<Comment> postComments = new();

            connection.Open();

            string query = "EXEC get_post_comments @PostID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PostID", postId);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Comment comment = new()
                    {
                        CommentID = ConvertFromDBVal<int>(reader["CommentID"]),
                        UserID = ConvertFromDBVal<int>(reader["UserID"]),
                        Text = ConvertFromDBVal<string>(reader["Text"]),
                        Name = ConvertFromDBVal<string>(reader["Name"]),
                        ImageURL = ConvertFromDBVal<string>(reader["ImageUrl"])
                    };
                    postComments.Add(comment);
                }
                command.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return postComments;
        }
    }
}
