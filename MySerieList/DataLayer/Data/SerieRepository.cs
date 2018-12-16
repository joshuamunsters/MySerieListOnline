using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DataLayer
{
    public class SerieRepository 
    {
        ISerieContext _serieContext = new SerieContext();


        public IEnumerable<Serie> Series()
        {
         
          return _serieContext.GetAllSeries();
         }
        
        public IEnumerable<Serie> GetSerieByCategory(int categoryid)
        {
            return _serieContext.GetAllSeriesByCategory(categoryid);
            
        }

        public Serie GetSerieById(int id)
        {
           return _serieContext.GetSerieById(id);
        }

        public void DeleteSerie(int id)
        {
            _serieContext.DeleteSerie(id);
        }
    }
}
