using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class RecommendationContext : IRecommendationContext
    {
        private string ConnectionString { get; set; } = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=MySerieList;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public List<Recommendation> GetRecommendatinsBySerieId(int serieid)
        {
            List<Recommendation> recommendations = new List<Recommendation>();
            string query = "SELECT * FROM Recommendation WHERE serieid1 = @serieid";
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
                                Recommendation recommendation = new Recommendation
                                {
                                    Id = (int)reader["id"],
                                    Name = (string)reader["name"],
                                    Description = (string)reader["description"],
                                    Userid = (int)reader["userid"],
                                    Serie1 = new Serie
                                    {
                                        Id = (int)reader["serieid1"],
                                    },
                                    Serie2 = new Serie
                                    {
                                        Id = (int)reader["serieid2"],
                                    }
                                };
                                recommendations.Add(recommendation);
                            }
                        }
                    }
                }
                return recommendations;



            }
        }

        public void CreateRecommendation(Recommendation recommendation)
        {
            try
            {
                string query = "IF EXISTS(SELECT * FROM Recommendation WHERE name = @name AND userid=@userid) UPDATE Recommendation SET description=@description WHERE name=@name AND userid=@userid ELSE INSERT INTO Recommendation([name], [description], [serieid1], [serieid2], [userid]) VALUES(@name, @description, @serieid1, @serieid2, @userid)";


                using (var conn = new SqlConnection(ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@name", recommendation.Name);
                        cmd.Parameters.AddWithValue("@description", recommendation.Description);
                        cmd.Parameters.AddWithValue("@serieid1", recommendation.Serie1.Id);
                        cmd.Parameters.AddWithValue("@serieid2", recommendation.Serie2.Id);
                        cmd.Parameters.AddWithValue("@userid", recommendation.Userid);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
