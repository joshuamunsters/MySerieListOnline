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
            string query = "INSERT INTO WatchListSeries([id], [name], [status], [episodesseen], [rating], [userid])" +
                           "VALUES(@id, @name, @status, @episodesseen, @rating, @userid)";

            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@id", watchListSerie.Id);
                    cmd.Parameters.AddWithValue("@name", watchListSerie.Name);
                    cmd.Parameters.AddWithValue("@status", watchListSerie.Status);
                    cmd.Parameters.AddWithValue("@episodesseen", watchListSerie.EpisodesSeen);
                    cmd.Parameters.AddWithValue("@rating", watchListSerie.Rating);
                    cmd.Parameters.AddWithValue("@userid", watchListSerie.UserId);
                    


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<WatchListSerie> GetSeries()
        {
            List<WatchListSerie> series = new List<WatchListSerie>();
            string query = "SELECT id, name, status, episodesseen, rating, userid FROM WatchListSeries";
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
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
                                    EpisodesSeen = (int)reader["episodesseen"],
                                    Rating = (int)reader["rating"],
                                    UserId = (int)reader["userid"]

                                };
                                series.Add(serie);
                            }
                        }
                    }
                }

                return series;
            }
        }


    }
}
