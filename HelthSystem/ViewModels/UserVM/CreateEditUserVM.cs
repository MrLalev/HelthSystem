using HelthSystem.ValidationAtribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelthSystem.ViewModels.UserVM
{
    public class CreateEditUserVM : BaseWithIdVM
    {
        [Required(ErrorMessage = "Please enter a First name")]
        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last name")]
        [Display(Name = "Last name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a E-mail")]
        [Display(Name = "E-mail:")]
        [UniqueEmail("Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pleass repeat password")]
        [Display(Name = "Repeat password:")]
        [MatchValue("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Please enter a Adress")]
        [Display(Name = "Adress:")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Please enter a Phone")]
        [Display(Name = "Phone:")]
        public string Phone { get; set; }
    }
}