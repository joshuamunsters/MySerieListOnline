using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogicLayer;
using MySerieList.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySerieList.Controllers
{
    public class EpisodeController : Controller
    {
        // GET: /<controller>/
        EpisodeLogic episodeLogic = new EpisodeLogic();

        public ViewResult Episode(int serieid)
        {

            var vm = new EpisodeViewModel()
            {
                Episodes = episodeLogic.GetEpisodeBySerieId(serieid)
            };


            return View(vm);
        }
    }
}
