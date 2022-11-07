using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class SqlConnectionFactory
    {
        private const string _connectionString = "Server=tcp:220926netp2dbs.database.windows.net,1433;Initial Catalog=FlareDB;Persist Security Info=False;User ID=flareadmin;Password=fl@a5z123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
