using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Data.SqlClient;
using Interfaces;

namespace DataLayer
{
    class WatchListContext : IWatchListContext
    {
        private string ConnectionString { get; set; } = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=MySerieList;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public void SendWatchListSerie(WatchListSerie watchListSerie)
        {
            //string query = "INSERT INTO WatchListSeries([serieid], [name], [status], [episodesseen], [rating], [userid])" +
            //               "VALUES(@serieid, @name, @status, @episodesseen, @rating, @userid)";

            string query = "IF EXISTS(SELECT * FROM WatchListSeries WHERE name = @name AND userid=@userid) UPDATE WatchListSeries SET rating=@rating, status=@status, episodesseen=@episodesseen WHERE name=@name AND userid=@userid ELSE INSERT INTO WatchListSeries([serieid], [name], [status], [episodesseen], [rating], [userid]) VALUES(@serieid, @name, @status, @episodesseen, @rating, @userid)";


            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@serieid", watchListSerie.SerieId);
                    cmd.Parameters.AddWithValue("@name", watchListSerie.Name);
                    cmd.Parameters.AddWithValue("@status", watchListSerie.Status);
                    cmd.Parameters.AddWithValue("@episodesseen", watchListSerie.EpisodesSeen);
                    cmd.Parameters.AddWithValue("@rating", watchListSerie.Rating);
                    cmd.Parameters.AddWithValue("@userid", watchListSerie.User.Id);
                    


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<WatchListSerie> GetSeries(int userid)
        {
            List<WatchListSerie> series = new List<WatchListSerie>();
            string query = "SELECT id, name, status, episodesseen, rating, userid, serieid FROM WatchListSeries WHERE userid = @userid";
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@userid", userid));
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                WatchListSerie serie = new WatchListSerie()
                                {
                                    Id = (int)reader["id"],
                                    Name = (string)reader["name"],
                                    Status = (string)reader["status"],
                                    EpisodesSeen = (string)reader["episodesseen"],
                                    Rating = (int)reader["rating"],
                                    User = new User
                                    {
                                        Id = (int)reader["userid"]
                                    },

                                    SerieId = (int)reader["serieid"]

                                };
                                series.Add(serie);
                            }
                        }
                    }
                }

                return series;
            }
        }

        public List<Serie> GetMostPopularSeries()
        {
            string query = "SELECT  TOP 4 a.serieid, b.[name], b.[description], b.overallrating, COUNT(serieid) AS MOST_FREQUENT from WatchListSeries AS a INNER JOIN Serie AS b ON b.id = a.serieid GROUP BY serieid, b.[name], b.[description], b.overallrating ORDER BY COUNT(serieid) desc ";
            List<Serie> series = new List<Serie>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Serie serie = new Serie()
                            {
                                Id = (int)reader["serieid"],
                                Name = (string)reader["name"],
                                Description = (string)reader["description"],
                                Overallrating = (string)reader["overallrating"]

                            };
                            series.Add(serie);
                        }

                        return series;
                    }
                }
            }
        }

        public void DeleteSerieFromWatchList(int serieid, int userid)
        {

            string query = "DELETE FROM WatchListSeries WHERE serieid=@serieid AND userid=@userid";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@serieid", serieid);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
