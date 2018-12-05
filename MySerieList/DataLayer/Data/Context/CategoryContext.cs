using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Interfaces;

namespace DataLayer
{
    class CategoryContext : ICategoryContext
    {
        private string ConnectionString { get; set; } = "Server=tcp:joshhq.database.windows.net,1433;Initial Catalog=MySerieList;Persist Security Info=False;User ID=joshhq;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            string query = "SELECT id, name, description FROM Category";
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
                                Category category = new Category
                                {
                                    id = (int)reader["id"],
                                    name = (string)reader["name"],
                                    description = (string)reader["description"],


                                };
                                categories.Add(category);
                            }
                        }
                    }
                }
                return categories;



            }
        }
    }
}

