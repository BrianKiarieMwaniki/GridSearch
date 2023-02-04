using GridSearchApp.Db;
using GridSearchApp.Entities;
using System.Data.SqlClient;

namespace GridSearchApp.Services
{
    public class CustomerService : DbConnection
    {
        public IQueryable<Customer>? Customers { get; private set; }

        public List<Customer> CustomersList { get; private set; }

        private void GetCustomers()
        {
            CustomersList = new List<Customer>();

            using(var connection = GetConnection())
            {
                connection.Open();

                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select FirstName,LastName,City,Country,Phone from Customer";

                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        CustomersList.Add(new Customer
                        {
                            FirstName = (string)reader[0],
                            LastName = (string)reader[1],
                            City = (string)reader[2],
                            Country = (string)reader[3],
                            Phone = (string)reader[4]
                        });
                    }

                    Customers = CustomersList.AsQueryable();
                }
            }
        }

        public bool LoadData()
        {
            GetCustomers();

            if (Customers is null) return false;

            return true;
        }
    }
}
