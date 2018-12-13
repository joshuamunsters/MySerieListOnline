using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface ISerieContext
    {
        List<Serie> GetAllSeries();
        List<Serie> GetAllSeriesByCategory(int categoryid);
        Serie GetSerieById(int id);

    }
}