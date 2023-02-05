using GridSearchApp.Db;
using GridSearchApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearchApp.Services
{
    public class UserService : DbConnection
    {
        public IQueryable<User>? Users { get; private set; } 

        private void GetUsers()
        {
            var usersList = new List<User>();

            using(var connection = GetConnection())
            {
                connection.Open();

                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT username, first_name, last_name, gender FROM user_details;";

                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        usersList.Add(new User
                        {
                            Username = (string)reader[0],
                            Firstname = (string)reader[1],
                            Lastname = (string)reader[2],
                            Gender = (string)reader[3]
                        });
                    }

                    Users = usersList.AsQueryable();
                }
            }
        }

        public bool LoadData()
        {
            GetUsers();

            if (Users is null) return false;

            return true;
        }
    }
}
