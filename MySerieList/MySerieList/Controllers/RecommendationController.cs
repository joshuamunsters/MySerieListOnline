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
    public class RecommendationController : Controller
    {
        RecommendationLogic recommendationLogic = new RecommendationLogic();
        SerieLogic serieLogic = new SerieLogic();

        public IActionResult Recommendation(int serieid)
        {
            RecommendationViewModel vm = new RecommendationViewModel();
            vm.GetRecommendations = recommendationLogic.GetRecommendatinsBySerieId(serieid);
            vm.GetSerieNames = serieLogic.Series();
            vm.Serieid = serieid;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Recommendation(RecommendationViewModel vm)
        {
            recommendationLogic.CreateRecommendation(vm.CreateRecommendation);


            return RedirectToAction("Recommendation", "Recommendation", new { serieid = vm.CreateRecommendation.Serie1.Id });
        }


    }
}
