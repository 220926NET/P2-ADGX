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
                        CommentID = (int)reader["CommentID"],
                        UserID = (int)reader["UserID"],
                        PostID = postId,
                        Text = (string)reader["Text"]
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
