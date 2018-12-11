using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IEpisodeContext
    {
        List<Episode> GetEpisodeBySerieId(int serieid);

        void CreateRating(EpisodeRating rating);

        EpisodeRating GetEpisodeRating(int episodeId);
    }
}