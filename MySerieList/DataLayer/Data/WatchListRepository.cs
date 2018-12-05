﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DataLayer
{
    public class WatchListRepository 
    {
        IWatchListContext watchListContext = new WatchListContext();

        public void SendWatchListSerie(WatchListSerie watchListSerie)
        {
            watchListContext.SendWatchListSerie(watchListSerie);
        }

        public List<WatchListSerie> GetSeries()
        {
          return  watchListContext.GetSeries();
        }
    }
}
