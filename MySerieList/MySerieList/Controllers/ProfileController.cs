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
    public class ProfileController : Controller
    {

        LoginLogic loginLogic = new LoginLogic();
        // GET: /<controller>/
        public IActionResult Profile(string email)
        {
            ProfileViewModel vm = new ProfileViewModel();
            vm.Profile = loginLogic.GetUserByEMail(email);

            return View(vm);
        }
    }
}
