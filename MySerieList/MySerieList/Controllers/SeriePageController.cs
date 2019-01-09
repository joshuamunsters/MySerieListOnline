using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySerieList.ViewModels;
using LogicLayer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySerieList.Controllers
{
    public class SeriePageController : Controller
    {
        SerieLogic serieLogic = new SerieLogic();
        ReviewLogic reviewLogic = new ReviewLogic();

        public ViewResult Page(int id)
        {
            var seriePageViewModel = new SeriePageViewModel
            {
                SelectedSerie = serieLogic.GetSerieById(id),
                Reviews = reviewLogic.GetReviewBySerie(id)
            };
            return View(seriePageViewModel);
        }

        [HttpPost, ActionName("Page")]
        public IActionResult PageReview(SeriePageViewModel viewModel)
        {
            //viewModel.SendReview.Serieid = viewModel.SelectedSerie.id;

            //mockcode : serieRepo.NewReview(viewModel.SendReview);
            reviewLogic.SendReview(viewModel.SendReview);


            return RedirectToAction("Page", "SeriePage", new { id = viewModel.SendReview.Serieid });
        }
    }
}
