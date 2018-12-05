using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySerieList.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Username")]
        public string Username { get; set; }

        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password does not match the confirmation password")]
        public string ConfirmPassword { get; set; }

        [Required, Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }



    }
}
