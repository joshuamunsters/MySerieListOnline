﻿using System;
using DataLayer;
using Models;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LogicLayer
{
    public class SerieLogic
    {
        SerieRepository serieRepository = new SerieRepository();
        
       public string currentcategory = string.Empty;

        public IEnumerable<Serie> Series()
        {

            return serieRepository.Series();
        }


        public Serie GetSerieById(int id)
        {
            return serieRepository.GetSerieById(id);
        }
        public IEnumerable<Serie> List(string category)
        {
            string _category = category;
            IEnumerable<Serie> series;


            if (string.Equals("All Series", _category, StringComparison.OrdinalIgnoreCase))
            {
                series = serieRepository.Series().OrderBy(n => n.Id);
                //currentcategory = "All Series";
            }
            else
            {
                if (string.Equals("Action", _category, StringComparison.OrdinalIgnoreCase))
                {
                    series = serieRepository.GetSerieByCategory(1);
                }
                else
                {
                    series = serieRepository.GetSerieByCategory(2);
                }
                currentcategory = _category;

            }
            return series;
        }

        public IEnumerable<Serie> ListSearch(string searchbox)
        {
            string _searchString = searchbox;
            IEnumerable<Serie> serie;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                serie = serieRepository.Series().OrderBy(p => p.Id);
            }
            else
            {
                serie = serieRepository.Series().Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }
            return serie;
        }
        
        public List<Serie> AutoComplete(string Prefix)
        {
            List<Serie> allseries = serieRepository.Series().Where(x => x.Name.Contains(Prefix)).Select(x => new Serie
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return allseries;
        }

        public void DeleteSerie(int id)
        {
            serieRepository.DeleteSerie(id);
        }
    }
}
