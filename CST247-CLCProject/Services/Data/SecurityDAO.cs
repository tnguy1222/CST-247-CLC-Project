using CST247_CLCProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CST247_CLCProject.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=User;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public bool create(UserModel user)
        {
            bool success = false;
            string queryString = "INSERT INTO dbo.users (Id, Firstname, Lastname, Sex, Age, Email, Username , Password) VALUES(0, @Firstname, @Lastname, @Sex, @Age, @Email, @Username , @Password )";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", 0);
                command.Parameters.AddWithValue("@Firstname", "Firstname");
                command.Parameters.AddWithValue("@Lastname", "Lastname");
                command.Parameters.AddWithValue("@Sex", "Sex");
                command.Parameters.AddWithValue("@Age", "Age");
                command.Parameters.AddWithValue("@Email", "Email");
                command.Parameters.AddWithValue("@Username", "Username");
                command.Parameters.AddWithValue("@Password", "Password");
                connection.Open();

                int result = command.ExecuteNonQuery();

                if (result < 0)
                    Console.WriteLine("Item is inserted");
            }
            return success;
        }

        public bool authenticate(UserModel user)
        {
            bool success = false;
            return success;
        }
    }
}