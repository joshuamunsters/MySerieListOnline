﻿using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer;
using MySerieList.ViewModels;
using Models;

namespace MySerieList.Controllers
{
    public class WatchListController : Controller
    {

        WatchListLogic watchListLogic = new WatchListLogic();

        public ViewResult Index()
        {

            var watchListViewModel = new WatchListViewModel()
            {
                Series = watchListLogic.GetSeries()
            };
          
            
            return View(watchListViewModel);
        }
        [HttpPost, ActionName("Index")]
        public IActionResult SendSerie(SeriePageViewModel viewModel)
        {

            watchListLogic.AddToWatchList(viewModel.WatchList.Serie);


            return RedirectToAction("Index", "WatchList");
        }


    }
}
