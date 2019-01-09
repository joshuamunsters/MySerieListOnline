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
            string query = "INSERT INTO Review([reviewtext], [serieid], [userid], [date])" +
                           "VALUES(@reviewtext, @serieid, @userid, @date)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@reviewtext", review.Reviewtext);
                    cmd.Parameters.AddWithValue("@serieid", review.Serieid);
                    cmd.Parameters.AddWithValue("@userid", review.User.Id);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Review> GetReviewBySerie(int serieid)
        {
            List<Review> reviews = new List<Review>();
            string query = "SELECT * FROM Review AS a INNER JOIN [User] AS b ON a.userid = b.id WHERE serieid = @serieid";
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@serieid", serieid));
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Review review = new Review
                                {
                                    Id = (int)reader["id"],
                                    Reviewtext = (string)reader["reviewtext"],
                                    Serieid = (int)reader["serieid"],
                                    Date = (DateTime)reader["date"],
                                    User = new User
                                    {
                                        Id = (int)reader["userid"],
                                        Username = (string)reader["username"]
                                    }
                                    

                                };
                               
                                reviews.Add(review);
                            }
                        }
                    }
                }
                return reviews;



            }
        }
    }
}
