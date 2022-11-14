
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using Models;
public class ProfileRepository : IProfileRepository
{

    private readonly SqlConnection _connection = SqlConnectionFactory.GetConnection();

    public async Task<bool> UploadUserPhoto(int userId, string imageUrl, string imageFileName)
    {
        ResponseMessage<string> uploadUserPostRes = new ResponseMessage<string>();
        try
        {

            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec add_user_photo @UserId, @ImageUrl, @ImageName", _connection);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);
            cmd.Parameters.AddWithValue("@ImageName", imageFileName);
            int rowsAffected = await cmd.ExecuteNonQueryAsync();
            _connection.Close();
            return true;
        }
        catch (SqlException)
        {
            return false;

        }
        finally
        {
            _connection.Close();
        }

    }

    /// This method checks to see if an image has already been uploaded by the user
    /// <param name="userId">The userId used to check if a profile photo has been set</param> 
    /// <returns>
    /// true if user id has profile photo
    /// </returns> 
    public async Task<bool> UserHasProfilePhoto(int userId)
    {
        //create Proc user_photo_exists @ImageHash varchar(255), @UserId int
        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec user_has_photo @userId", _connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string? userPhoto = reader["ImageUrl"].ToString();

                    if (userPhoto != null)
                    {
                        _connection.Close();
                        return true;
                    }

                }

            }
        }
        catch (SqlException)
        {
            //TODO: Log error to file 

        }
        finally
        {
            _connection.Close();
        }

        return false;

    }

    public async Task<string?> GetProfilePhoto(int userId)
    {
        string? userPhoto = null;
        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec user_has_photo @userId", _connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userPhoto = reader["ImageUrl"].ToString();

                }

            }
        }
        catch (SqlException)
        {

            //TODO: Log error to file 

        }
        finally
        {
            _connection.Close();
        }

        return userPhoto;
    }

    public async Task<string?> DeleteUserPhoto(int userId)
    {
        string? fileNameToDelete = null;

        try
        {
            _connection.Open();
            //TODO: retrieve deleted file name if any 
            SqlCommand cmd = new SqlCommand("exec delete_user_photo @UserId ", _connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    fileNameToDelete = reader["ImageName"].ToString()!;
                    return fileNameToDelete;
                }

            }

        }

        catch (SqlException)

        {

            //TODO: Log error to file 

        }
        finally
        {
            _connection.Close();
        }

        return fileNameToDelete;
    }


    public async Task<bool> UploadUserHobbies(int userId, ProfileHobbies hobbies)
    {

        try
        {

            _connection.Open();

            foreach (string hobby in hobbies.Hobbies)
            {
                //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
                SqlCommand cmd = new SqlCommand("exec create_profile_hobby @UserId, @Text", _connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Text", hobby);
                int rowsAffected = await cmd.ExecuteNonQueryAsync();

            }

            _connection.Close();
            return true;


        }
        catch (SqlException)
        {
            //TODO: Log error to file
            _connection.Close();
            return false;

        }


    }

    public async Task<List<string>> GetProfileHobbies(int userId)
    {
        List<string> hobbies = new List<string>();
        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec get_profile_hobbies @userId", _connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string hobby = (string)reader["Text"];
                    hobbies.Add(hobby);
                }
            }
        }
        catch (SqlException)
        {
            //TODO: Log error to file 

        }
        finally
        {
            _connection.Close();
        }
        return hobbies;
    }

    public async Task<bool> DeleteUserHobbies(int userId)
    {

        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec delete_profile_hobbies @userId", _connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            await cmd.ExecuteNonQueryAsync();
            _connection.Close();
            return true;
        }
        catch (SqlException)
        {
            //TODO: Log error to file 
            return false;
        }


    }


    public async Task<bool> UploadProfileInterests(int userId, ProfileInterests interests)
    {
        try
        {

            _connection.Open();

            foreach (string interest in interests.Interests)
            {

                Console.WriteLine("interest are " + interest);
                //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
                SqlCommand cmd = new SqlCommand("exec create_profile_interest @UserId, @Text", _connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Text", interest);
                int rowsAffected = await cmd.ExecuteNonQueryAsync();


            }
            _connection.Close();
            return true;
        }
        catch (SqlException)
        {
            //TODO: Log error to file
            _connection.Close();
            return false;


        }


    }

    public async Task UploadUserInterests(int userId, ProfileInterests interests)
    {

        try
        {

            _connection.Open();

            foreach (string interest in interests.Interests)
            {
                //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
                SqlCommand cmd = new SqlCommand("exec create_profile_interest @UserId, @Text", _connection);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Text", interest);
                int rowsAffected = await cmd.ExecuteNonQueryAsync();

            }
        }
        catch (SqlException)
        {
            //TODO: Log error to file



        }
        finally
        {
            _connection.Close();
        }

    }


    public async Task<List<string>> GetProfileInterests(int userId)
    {
        List<string>? profileInterests = new List<string>();
        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec get_profile_interests @userId", _connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string interest = (string)reader["Text"];
                    profileInterests.Add(interest);
                }
            }
        }
        catch (SqlException)
        {
            //TODO: Log error to file 

        }
        finally
        {
            _connection.Close();
        }

        return profileInterests;


    }

    public async Task<bool> DeleteProfileInterests(int userId)
    {

        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec delete_profile_interests @UserId", _connection);
            cmd.Parameters.AddWithValue("@UserId", userId);
            await cmd.ExecuteNonQueryAsync();
            _connection.Close();
            return true;
        }
        catch (SqlException e)
        {
            Console.WriteLine(e);
            //TODO: Log error to file 
            _connection.Close();
            return false;
        }

    }


    public async Task<bool> SetProfileAboutMe(int userId, ProfileAboutMe aboutMe)
    {
        try
        {

            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec add_profile_about_me @UserId, @AboutMe", _connection);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@AboutMe", aboutMe.AboutMe);
            await cmd.ExecuteNonQueryAsync();
            _connection.Close();
            return true;

        }


        catch (SqlException)
        {
            //TODO: Log error to file
            return false;
        }
        finally
        {
            _connection.Close();
        }


    }

    public async Task<string> GetProfileAboutMe(int userId)
    {

        string aboutMeRes = "";
        try
        {

            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec get_profile_about_me @UserId", _connection);
            cmd.Parameters.AddWithValue("@UserId", userId);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["AboutMe"] != DBNull.Value)
                    {
                        aboutMeRes = (string)reader["AboutMe"];
                    }

                }
            }
        }
        catch (SqlException)
        {
            //TODO: Log error to file

        }
        finally
        {
            _connection.Close();
        }

        return aboutMeRes;
    }

    public async Task<bool> DeleteProfileAboutMe(int userId)
    {

        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec delete_profile_about_me @UserId", _connection);
            cmd.Parameters.AddWithValue("@UserId", userId);
            await cmd.ExecuteNonQueryAsync();
            return true;
        }
        catch (SqlException)
        {
            //TODO: Log error to file 
            return false;
        }
        finally
        {
            _connection.Close();
        }

    }
    public async Task<bool> UserImagePostAlreadyExists(string imageName)
    {
        try
        {
            _connection.Open();
            //exec insert_into_articles "emmanuiel", "title", "description", "url", "urltoiamge", "2022-05-09", 1
            SqlCommand cmd = new SqlCommand("exec user_post_already_exists @ImageHash", _connection);
            cmd.Parameters.AddWithValue("@ImageHash", imageName);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                _connection.Close();
                return true;
            }
        }
        catch (SqlException)
        {
            //TODO: Log error to file 
            return false;
        }
        finally
        {
            _connection.Close();
        }

        return false;
    }
}