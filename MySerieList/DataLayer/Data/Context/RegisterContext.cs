
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Models;
using Interfaces;

namespace DataLayer
{
    public class RegisterContext : IRegisterContext
    {
        private string ConnectionString { get; set; } = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=MySerieList;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public void Register(User user)
        {
            string query = "INSERT INTO [User]([username], [password], [email])" +
                           "VALUES(@username, @password, @email)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@email", user.Email);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

