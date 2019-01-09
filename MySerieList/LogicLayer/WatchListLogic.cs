using DataLayer;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace LogicLayer
{
    public class WatchListLogic
    {

        //public ISerieRepository serieRepository { get; set; } 
        public WatchListRepository watchListRepository { get; set; } = new WatchListRepository();

        public void AddToWatchList(WatchListSerie watchListSerie)
        {
            watchListRepository.SendWatchListSerie(watchListSerie);

        }

        public List<WatchListSerie> GetSeries(int userid)
        {
            return watchListRepository.GetSeries(userid);
        }

        public List<Serie> GetMostPopularSeries()
        {
            return watchListRepository.GetMostPopularSeries();
        }

        public void DeleteSerieFromWatchList(int serieid, int userid)
        {
            watchListRepository.DeleteSerieFromWatchList(serieid, userid);
        }




    }
}
