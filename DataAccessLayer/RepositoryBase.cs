using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public abstract class RepositoryBase<T> where T : new()
{
    protected readonly string tableName;
    public RepositoryBase(string tableName)
    {
        this.tableName = tableName;
    }

    protected abstract T EntityRead(SqlDataReader reader);

    protected T EntityGet(SqlCommand command)
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

    protected List<T> EntityGetList(SqlCommand command)
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

    protected void EntityNonQuery(SqlCommand command)
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