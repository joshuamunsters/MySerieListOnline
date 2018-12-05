using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Interfaces;

namespace DataLayer
{
   public class SerieContext : ISerieContext
    {
        private string ConnectionString { get; set; } = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=MySerieList;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public List<Serie> GetAllSeries()
        {
            List<Serie> series = new List<Serie>();
            string query = "SELECT id, name, description, overallrating FROM Serie";
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
                                Serie serie = new Serie
                                {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    description = (string)reader["description"],
                                    overallrating = (string)reader["overallrating"]
                                    
                                };
                               series.Add(serie);
                            }
                        }
                    }
                }

                return series;
            }
        }

        public List<Serie> GetAllSeriesByCategory(int categoryid)
        {
            List<Serie> series = new List<Serie>();
            //string query = "SELECT id, name, description, overallrating FROM Serie WHERE categoryid = @categoryid";
            using (var conn = new SqlConnection(ConnectionString))
            {             
                conn.Open();
                using (var cmd = new SqlCommand("GetSeriesByCategory", conn))
                {              
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@categoryid", categoryid));
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Serie serie = new Serie
                                {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    description = (string)reader["description"],
                                    overallrating = (string)reader["overallrating"]

                                };
                                series.Add(serie);
                            }
                        }
                    }
                }

                return series;
            }
        }

        public Serie GetSerieById(int id)
        {
            string query = "SELECT id, name, description, overallrating FROM Serie WHERE Id= @Id";
            var serie = new Serie();
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            serie = new Serie()
                            {
                                id = id,
                                name = (string)reader["name"],
                                description = (string)reader["description"],
                                overallrating = (string)reader["overallrating"]
                            
                            };
                        }

                        return serie;
                    }
                }
            }
        }

        public Serie GetSerieByName(string name)
        {
            string query = "SELECT id, name, description, overallrating FROM Serie WHERE name= @Name";
            var serie = new Serie();
            using (var conn = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Name", name);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            serie = new Serie()
                            {
                                id = (int)reader["id"],
                                name = name,
                                description = (string)reader["description"],
                                overallrating = (string)reader["overallrating"]

                            };
                        }

                        return serie;
                    }
                }
            }
        }



    }
}
