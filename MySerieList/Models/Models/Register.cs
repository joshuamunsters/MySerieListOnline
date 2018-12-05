using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Register
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Username can't be empty")]
        [Display(Name = "username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [Display(Name = "email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email not valid!")]
        public string email { get; set; }
    }
}
