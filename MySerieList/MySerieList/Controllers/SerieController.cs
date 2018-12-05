using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySerieList.ViewModels;
using Models;
using LogicLayer;
using Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySerieList.Controllers
{
    public class SerieController : Controller
    {
        SerieLogic serieLogic = new SerieLogic();

        public ViewResult List(string category)
        {

            //SerieListViewModel vm = new SerieListViewModel();
            //vm.Series = _serieRepository.GetSerieByCategory(1);
            //vm.Categories = _categoryRepository.Categories();
            //vm.CurrentCategory = "All";
            //return View(vm);


            var serieListViewModel = new SerieListViewModel
            {
                Series = serieLogic.List(category),
                CurrentCategory = serieLogic.currentcategory,
                Categories = serieLogic.categoryRepository.Categories()


            };
            return View(serieListViewModel);



        }

        public ViewResult Page(int id)
        {
            var seriePageViewModel = new SeriePageViewModel
            {
                SelectedSerie = serieLogic.serieRepository.GetSerieById(id)
            };
            return View(seriePageViewModel);
        }

        [HttpPost, ActionName("Page")]
        public IActionResult PageReview(SeriePageViewModel viewModel)
        {
            //viewModel.SendReview.Serieid = viewModel.SelectedSerie.id;

            //mockcode : serieRepo.NewReview(viewModel.SendReview);
            serieLogic.reviewRepository.SendReview(viewModel.SendReview);


            return RedirectToAction("Page", "Serie", new { id = viewModel.SendReview.Serieid });
        }
    }
}

