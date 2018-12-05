using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class LoginContext
    {
        private string ConnectionString { get; set; } = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=MySerieList;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public bool LoginCheck(string eMail, string passWord)
        {
            string query = "SELECT COUNT(*) FROM [User] WHERE Email=@Email AND Password=@Password";
            bool logInIsValid;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", eMail);
            cmd.Parameters.AddWithValue("@Password", passWord);
            int UserExist = (int)cmd.ExecuteScalar();

            if (UserExist > 0)
            {
                logInIsValid = true;
            }
            else
            {
                logInIsValid = false;
            }
            conn.Close();
            return logInIsValid;
            
        }

            
        

        public User GetUserByEMail(string eMail)
        {
            User user = new User();
            string query = $"SELECT id, username, password, email, roleid FROM [User] WHERE email=@email";

            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@email", eMail));
                    conn.Open();
                    foreach (DbDataRecord record in cmd.ExecuteReader())
                    {
                        user = new User
                        {
                            Id = record.GetInt32(record.GetOrdinal("id")),
                            Username = record.GetString(record.GetOrdinal("username")),
                            Password = record.GetString(record.GetOrdinal("password")),
                            Email = record.GetString(record.GetOrdinal("email")),
                            Roleid = record.GetInt32(record.GetOrdinal("roleid")),
                        };
                    }
                }
            }

            return user;
        }

    }
}
