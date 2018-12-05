using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
   public  interface IWatchListRepository
    {
        void SendWatchListSerie(WatchListSerie watchListSerie);

        List<WatchListSerie> GetSeries();

    }
}
