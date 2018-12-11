using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class EpisodeContext : IEpisodeContext
    {
        private string ConnectionString { get; set; } = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=MySerieList;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public List<Episode> GetEpisodeBySerieId(int serieid)
        {
            List<Episode> episodes = new List<Episode>();
            string query = "SELECT id, name, description, serieid FROM Episode WHERE serieid = @serieid";
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
                                Episode category = new Episode
                                {
                                    Id = (int)reader["id"],
                                    Name = (string)reader["name"],
                                    Description = (string)reader["description"],
                                    Serieid = (int)reader["serieid"]


                                };
                                episodes.Add(category);
                            }
                        }
                    }
                }
                return episodes;



            }
        }

        public void CreateRating(EpisodeRating rating)
        {
            string query = "INSERT INTO Episoderating([rating], [episodeid], [userid])" +
                           "VALUES(@rating, @episodeid, @userid)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@rating", rating.Rating);
                    cmd.Parameters.AddWithValue("@episodeid", rating.Episodeid);
                    cmd.Parameters.AddWithValue("@userid", rating.Userid);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EpisodeRating GetEpisodeRating(int epsiodeId)
        {
            string query = "SELECT id, rating, episodeid, userid FROM Episoderating WHERE episodeid= @episodeid";
            EpisodeRating rating = new EpisodeRating();
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@episodeid", epsiodeId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rating = new EpisodeRating
                            {
                                Id = (int)reader["id"],
                                Rating = (int)reader["rating"],
                                Episodeid = epsiodeId,
                                Userid = (int)reader["userid"]

                            };
                        }

                        return rating;
                    }
                }
            }
        }
    }
}
