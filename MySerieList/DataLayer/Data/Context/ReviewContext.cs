using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Data.SqlClient;
using Interfaces;

namespace DataLayer
{
    class ReviewContext : IReviewContext
    {
        private string ConnectionString { get; set; } = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=MySerieList;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public void SendReview(Review review)
        {
            string query = "INSERT INTO Review([reviewtext], [serieid])" +
                           "VALUES(@reviewtext, @serieid)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    
                    cmd.Parameters.AddWithValue("@reviewtext", review.Reviewtext);
                    cmd.Parameters.AddWithValue("@serieid", review.Serieid);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
