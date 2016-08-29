using HelthSystem.ValidationAtribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelthSystem.ViewModels.DoctorVM
{
    public class CreateEditDoctorVM:BaseWithIdVM
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

        //[Required(ErrorMessage = "Please enter a Position")]
        [Display(Name = "Position:")]
        public string Position { get; set; }

        //[Required(ErrorMessage = "Please enter a Description")]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter admin role")]
        [Display(Name = "Admin:")]
        public bool AdminRole { get; set; }

        public int userId { get; set; }
    }
}