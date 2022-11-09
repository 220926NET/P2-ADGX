using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public interface ICommentsRepository
    {
        List<Comment> GetPostComments(int postId);
    }
    public class CommentsRepository : ICommentsRepository
    {
        SqlConnection connection;
        public CommentsRepository()
        {
            connection = SqlConnectionFactory.GetConnection();
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
            catch(Exception)
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
