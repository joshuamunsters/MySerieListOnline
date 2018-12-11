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
        public IActionResult EpisodeRating(int episodeId, int serieid)
        {
            EpisodeRatingViewModel vm = new EpisodeRatingViewModel
            {
                GetEpisodeRating = episodeLogic.GetEpisodeRating(episodeId),
                Serieid = serieid


            };
  
            return View(vm);
        }

        [HttpPost]
        public IActionResult EpisodeRating(EpisodeRatingViewModel vm, int serieid, int episodeId)
        {

            episodeLogic.CreateRating(vm.CreateRating);



            return RedirectToAction("EpisodeRating", "EpisodeRating", new { episodeId = episodeId });
        }
    }
}
