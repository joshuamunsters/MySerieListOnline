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

        public void CreateRating(EpisodeRating rating)
        {
            episodeRepository.CreateRating(rating);
        }

        public EpisodeRating GetEpisodeRating(int episodeId, int userid)
        {
            return episodeRepository.GetEpisodeRating(episodeId, userid);
        }

        public List<EpisodeRating> GetEpisodeRatingsBySerieId(int serieid, int userid)
        {
            return episodeRepository.GetEpisodeRatingsBySerieId(serieid, userid);
        }
    }
}
