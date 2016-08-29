using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelthSystem.ViewModels.UserVM
{
    public class DetailsUserVM : BaseWithIdVM
    {
        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last name:")]
        public string LastName { get; set; }

        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Display(Name = "Adress:")]
        public string Adress { get; set; }

        [Display(Name = "Phone:")]
        public string Phone { get; set; }
    }
}