using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ISerieRepository
    {
        IEnumerable<Serie> Series();

        IEnumerable<Serie> GetSerieByCategory(int categoryid);

        Serie GetSerieById(int id);

        Serie GetSerieByName(string name);
    }
}
