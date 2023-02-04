using System.Data.SqlClient;

namespace GridSearchApp.Db
{
    public abstract class DbConnection
    {
        private readonly string _connectionString;

        public DbConnection()
        {
            _connectionString = "Data Source=BRIAN\\SQLEXPRESS;Initial Catalog=NorthwindStore;Integrated Security=True";
        }

        protected SqlConnection GetConnection() => new SqlConnection(_connectionString);
        
    }
}
