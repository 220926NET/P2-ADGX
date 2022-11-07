
using Microsoft.Data.SqlClient;
using Models;

namespace DataAccessLayer;
public class Repository
{

    private SqlConnection _connection;
    private string _connectionString = Secrets.GetOdbcStr();

    public Repository()
    {
        _connection = new SqlConnection(_connectionString);
    }


    //insert_user_post @Description varchar(255), @UserId int, @ImageHash varchar(255), @ImageExtension varchar(29), @ImagePath varchar(255)
    public async Task<ResponseMessage<string>> UploadUserPost(string imageHash, int userId, string description, string imageExtension, string imagePath)
    {

        ResponseMessage<string> uploadUserPostRes = new ResponseMessage<string>();
        try
        {

            _connection.Open();

            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec insert_user_post @Description varchar(255), @UserId int, @ImageHash varchar(255), @ImageExtension varchar(29), @ImagePath varchar(255)", _connection);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@ImageHash", imageHash);
            cmd.Parameters.AddWithValue("@ImageExtension", imageExtension);
            cmd.Parameters.AddWithValue("@ImagePath", imagePath);

            int rowsAffected = await cmd.ExecuteNonQueryAsync();

            if (rowsAffected > 0)
            {
                uploadUserPostRes.message = "Successfully added user Post";
                uploadUserPostRes.success = true;
            }

            _connection.Close();
            _connection.Open();


        }
        catch (SqlException e)
        {
            //TODO: Log error to file
            uploadUserPostRes.message = "There was an inssue uploading photo, Try again later!";
            uploadUserPostRes.success = false;
            Console.WriteLine(e.Message);

        }
        finally
        {
            _connection.Close();
        }

        return uploadUserPostRes;
    }


    /// This method checks to see if an image has already been uploaded by the user
    /// <param name="imageHash">The md5 hash string of the image being checked</param> 
    /// <returns>
    /// true if hash string is in the database
    /// </returns> 
    public bool UserImageAlreadyExists(string imageHash)
    {
        //create Proc user_photo_exists @ImageHash varchar(255), @UserId int
        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec  user_photo_exists @ImageHash", _connection);
            cmd.Parameters.AddWithValue("@ImageHash", imageHash);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            _connection.Close();

        }
        catch (SqlException e)
        {


            //TODO: Log error to file 
            Console.WriteLine(e.Message);

        }
        finally
        {
            _connection.Close();
        }

        return false;

    }

}