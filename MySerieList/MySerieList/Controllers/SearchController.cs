using Interfaces;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using MySerieList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySerieList.Controllers
{
    public class SearchController : Controller
    {
        SerieLogic serieLogic = new SerieLogic();

        [HttpPost]
        public JsonResult AutoComplete(string Prefix)
        {

            return Json(serieLogic.AutoComplete(Prefix));
        }

        public ViewResult ListSearch(string searchbox)
        {


            return View("~/Views/Serie/List.cshtml", new SerieListViewModel { Series = serieLogic.ListSearch(searchbox), CurrentCategory = "All Series", Categories = serieLogic.categoryRepository.Categories() });
        }

    }
}
