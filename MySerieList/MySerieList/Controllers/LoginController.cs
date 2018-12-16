using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogicLayer;
using MySerieList.ViewModels;
using Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySerieList.Controllers
{
    public class LoginController : Controller
    {
        private LoginLogic _logInLogic = new LoginLogic();
        private RegisterLogic _registerLogic = new RegisterLogic();

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            if (vm.Email != null && vm.Password != null)
            {
                bool logInArray = _logInLogic.LoginCheck(vm.Email, vm.Password);
                if (logInArray == true)
                {
                    User user = _logInLogic.GetUserByEMail(vm.Email);
                    LogUserIn(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }

            return View("Login", vm);
        }

        private void LogUserIn(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("roleid", user.Roleid.ToString()),
                new Claim("email", user.Email),
            };

            var claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)).Wait();
        }
    }
}
