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
    public class AutoCompleteController : Controller
    {
        SerieLogic serieLogic = new SerieLogic();

        [HttpPost]
        public JsonResult AutoComplete(string Prefix)
        {


            List<Serie> allseries = serieLogic.serieRepository.Series().Where(x => x.name.Contains(Prefix)).Select(x => new Serie
            {
                id = x.id,
                name = x.name
            }).ToList();
            return Json(allseries);
        }

        public ViewResult ListSearch(string searchbox)
        {


            return View("~/Views/Serie/List.cshtml", new SerieListViewModel { Series = serieLogic.ListSearch(searchbox), CurrentCategory = "All Series", Categories = serieLogic.categoryRepository.Categories() });
        }

    }
}
