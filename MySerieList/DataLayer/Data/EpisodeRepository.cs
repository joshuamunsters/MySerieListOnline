using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
   public class EpisodeRepository
    {
        IEpisodeContext episodeContext = new EpisodeContext();

        public List<Episode> GetEpisodeBySerieId(int serieid)
        {
           return episodeContext.GetEpisodeBySerieId(serieid);
        }
    }
}
