using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class EpisodeLogic
    {
        EpisodeRepository episodeRepository = new EpisodeRepository();

        public List<Episode> GetEpisodeBySerieId(int serieid)
        {
            return episodeRepository.GetEpisodeBySerieId(serieid);
        }
    }
}
