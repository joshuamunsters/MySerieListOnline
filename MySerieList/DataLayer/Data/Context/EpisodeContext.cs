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
    }
}
