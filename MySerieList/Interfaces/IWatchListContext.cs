using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IWatchListContext
    {
        List<WatchListSerie> GetSeries(int userid);
        void SendWatchListSerie(WatchListSerie watchListSerie);

        List<Serie> GetMostPopularSeries();
    }
}