//handles looking up stuff in database
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Models;

namespace DataAccessLayer;

public interface IAuthRepository : IDisposable
{
    User GetUser(string username, string password);
    User GetUser(int id);
    int CreateUser(string username, string password);
    void DeleteUser(int id);
    void UpdateUser(User user);
    bool VerifyPassword(string username, string password, string salt);
    string GetUserSalt(string username);
    bool LookupUser(string username);

}


public class AuthRepository : IAuthRepository
{
    private readonly SqlConnection conn;

    public AuthRepository()
    {
        conn = SqlConnectionFactory.GetConnection();
    }
    //receives user credentials
    //returns validation of successful login
    public User GetUser(string username, string password)
    {
        User user = new();
        if (LookupUser(username))
        {
            string salt = GetUserSalt(username);
            if (VerifyPassword(username, password, salt))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM Login WHERE username=@username";
                    SqlCommand cmd = new(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["LoginID"];
                        salt = (string)dataReader["salt"];
                        user.Id = id;
                        user.Username = username;
                        user.Password = password;
                    }
                    cmd.Dispose();
                }
                catch (SqlException)
                {
                    throw;
                }
                finally
                {
                    conn.Close();

                }
            }
        }
        return user;
    }

    public string GetUserSalt(string username)
    {
        string salt = "";
        try
        {
            conn.Open();
            string sql = "SELECT * FROM Login WHERE username=@username";
            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);

            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                salt = (string)dataReader["salt"];
            }
            cmd.Dispose();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close();

        }
        return salt;
    }

    public bool LookupUser(string username)
    {
        int count = 0;
        try
        {
            conn.Open();
            string sql = "SELECT COUNT(*) FROM Login WHERE username=@username";
            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            count = (int)cmd.ExecuteScalar();
            cmd.Dispose();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close();
        }

        return count > 0;

    }

    public bool VerifyPassword(string username, string password, string salt)
    {
        byte[] password_hash = GetHash(password + salt);
        int count = 0;
        try
        {
            conn.Open();
            string sql = "SELECT COUNT(*) FROM Login WHERE username=@username AND PasswordHash=@password_hash";
            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password_hash", password_hash);
            count = (int)cmd.ExecuteScalar();
            cmd.Dispose();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close();
        }

        return count > 0;
    }


    public int CreateUser(string username, string password)
    {
        int id = -1;
        if (!LookupUser(username))
            try
            {
                conn.Open();
                string sql = "INSERT INTO Login (username, PasswordHash, salt) OUTPUT INSERTED.LoginID VALUES(@username, @password_hash, @salt)";
                SqlCommand cmd = new(sql, conn);
                string salt = GetSalt();
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password_hash", GetHash(password + salt));
                cmd.Parameters.AddWithValue("@salt", salt);
                id = (int)cmd.ExecuteScalar();
                cmd.Dispose();
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        return id;
    }

    private static byte[] GetHash(string password)
    {
        using HashAlgorithm algorithm = SHA512.Create();
        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private static string GetSalt()
    {
        Random random = new();

        // Maximum length of salt
        int max_length = 32;

        // Empty salt array
        byte[] salt = new byte[max_length];

        // Build the random bytes
        random.NextBytes(salt);

        // Return the string encoded salt
        return Convert.ToBase64String(salt);
    }

    public void DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
    }

    public User GetUser(int id)
    {
        User user = new();
        try
        {
            conn.Open();
            string sql = "SELECT * FROM Login WHERE LoginID=@id";
            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                string salt = (string)dataReader["salt"];
                string username = (string)dataReader["username"];
                user.Id = id;
                user.Username = username;
            }
            cmd.Dispose();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close();
        }
        return user;
    }
}
// EOC