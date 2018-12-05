using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IWatchListContext
    {
        List<WatchListSerie> GetSeries();
        void SendWatchListSerie(WatchListSerie watchListSerie);
    }
}