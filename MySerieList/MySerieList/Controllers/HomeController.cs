using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogicLayer;
using MySerieList.ViewModels;

namespace MySerieList.Controllers
{
    public class HomeController : Controller
    {
        WatchListLogic watchListLogic = new WatchListLogic();
        public IActionResult Index()
        {
            var vm = new WatchListViewModel();
            vm.MostPopularSeries = watchListLogic.GetMostPopularSeries();

            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
