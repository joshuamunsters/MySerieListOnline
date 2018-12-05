using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MockSerieRepository : ISerieRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Serie> Series()
        {               
             return new List<Serie>
                {
                    new Serie {
                        name="The 100",
                        description="Crazy",
                        categoryid=1
                    },
                    new Serie {
                        name="Lost",
                        description="OMG",
                        categoryid=2
                    }
                    };
            
        }
        //public Serie GetSerieById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Serie> GetSerieByCategory(int categoryid)
        {
            throw new NotImplementedException();
        }
        public Serie GetSerieById(int id)
        {
            throw new NotImplementedException();
        }
        public Serie GetSerieByName(string name)
        {
            throw new NotImplementedException();
        }

    }
}
  

