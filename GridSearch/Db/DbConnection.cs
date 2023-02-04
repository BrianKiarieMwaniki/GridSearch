using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearch.Db
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
