
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
    public class RegisterController : Controller
    {
        RegisterLogic registerLogic = new RegisterLogic();

       public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel vm)
        {
            User user = new User();
            user.Username = vm.Username;
            user.Password = vm.Password;
            user.Email = vm.Email;
            registerLogic.Register(user);
            return RedirectToAction("Index", "Home");

        }

    }
}
