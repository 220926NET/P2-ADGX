using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public abstract class RepositoryBase<T> where T : new()
{
    public RepositoryBase()
    {
    }

    protected abstract T EntityRead(SqlDataReader reader);

    protected T ExecuteGet(SqlCommand command)
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return EntityRead(reader);
                }
                else
                {
                    return new T();
                }
            }
            catch(Exception)
            {
                // logging
                throw;
            }
        }
    }

    protected List<T> ExecuteGetList(SqlCommand command)
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                List<T> list = new();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(EntityRead(reader));
                }
                return list;
            }
            catch(Exception)
            {
                // logging
                throw;
            }
        }
    }

    protected void ExecuteNonQuery(SqlCommand command)
    {
        SqlConnection connection = ConnectionFactory.GetConnection();
        using (connection)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            catch
            {
                // Add serilog logging
                throw;
            }
        }
    }
}