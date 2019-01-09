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
        CategoryLogic categoryLogic = new CategoryLogic();

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
                Categories = categoryLogic.Categories()


            };
            return View(serieListViewModel);



        }


        public IActionResult DeleteSerie(int id)
        {

            serieLogic.DeleteSerie(id);

            return RedirectToAction("List", "Serie", new { category = "All Series" });
        }




    }
}

