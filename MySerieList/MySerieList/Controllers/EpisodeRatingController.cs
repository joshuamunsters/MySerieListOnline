using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using LogicLayer;
using MySerieList.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySerieList.Controllers
{
    public class EpisodeRatingController : Controller
    {

        EpisodeLogic episodeLogic = new EpisodeLogic();
        public IActionResult EpisodeRating(int episodeId,  int userid, int serieid)
        {
            EpisodeRatingViewModel vm = new EpisodeRatingViewModel();
            vm.SerieId = serieid;
            vm.EpisodeId = episodeId;
            vm.GetEpisodeRating = episodeLogic.GetEpisodeRating(episodeId, userid);
            vm.RatingChart = episodeLogic.GetEpisodeRatingsBySerieId(serieid, userid);



            var ratings = vm.RatingChart.OrderBy(x => x.Episode.Id).Select(x => x.Rating);
            var episodes = vm.RatingChart.OrderBy(x => x.Episode.Id).Distinct().Select( x => x.Episode.Id);

            ViewBag.Ratings = ratings;
            ViewBag.Episodes = episodes;
            





            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateRating(EpisodeRatingViewModel vm, int serieid)
        {

            episodeLogic.CreateRating(vm.CreateRating);



            return RedirectToAction("EpisodeRating", "EpisodeRating", new { episodeId = vm.CreateRating.Episode.Id, userid = vm.CreateRating.Userid, serieid = serieid });
        }
    }
}
