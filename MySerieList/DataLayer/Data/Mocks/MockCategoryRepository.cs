using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MockCategoryRepository:ICategoryRepository
    {
        public IEnumerable<Category> Categories()
        {
           
            
                return new List<Category>
                     {
                         new Category { name = "Adventure", description = "Exciting!" },
                         new Category { name = "Horror", description = "Spooky!" }
                     };
            
        }


    }
    
}
