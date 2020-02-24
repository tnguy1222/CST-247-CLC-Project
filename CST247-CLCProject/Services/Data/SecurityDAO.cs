using CST247_CLCProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CST247_CLCProject.Models.Data
{
    public class SecurityDAO
    {
        // conection name and connection source file
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=User;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool findUserByEmail(UserModel user)
        {
            //start with a false variable
            bool exist = false;

            // queryString with a placeholder
            string queryString = "select * from dbo.users where email = @email";

            //create and open connection iin using block, connection will be closed after command is executed
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create command and Parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 50).Value = user.Email;
                

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        exist = true;

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return exist;
        }
        public bool create(UserModel user)
        {
            //start with a false variable 
            bool success = false;

            // queryString with a placeholder
            string queryString = "insert into dbo.users (firstname, lastname, sex, age, email, username , password) values (@firstname, @lastname, @sex, @age, @email, @username , @password )";


            //create and open connection iin using block, connection will be closed after command is executed
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create command and Parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);
                
                command.Parameters.AddWithValue("@Firstname", user.Firstname);
                command.Parameters.AddWithValue("@Lastname", user.Lastname);
                command.Parameters.AddWithValue("@Sex", user.Sex);
                command.Parameters.AddWithValue("@Age", user.Age);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    success = true;
                    
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            return success;
        }

        public bool authenticate(CredentialModel credential)
        {
            //start with a false variable
            bool success = false;

            // queryString with a placeholder
            string queryString = "select * from dbo.users where username = @username and password = @password";
            
            //create and open connection iin using block, connection will be closed after command is executed
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create command and Parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = credential.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = credential.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                        
                    }
                    reader.Close();

                 // Exception handler that returns error message
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                return success;
        }
    }
}