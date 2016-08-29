using HelthSystem.ValidationAtribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelthSystem.ViewModels.AppointmentVM
{
    public class CreateEditAppointmentVM:BaseWithIdVM
    {
        [Required(ErrorMessage = "Please enter a Doctor")]
        [Display(Name = "Doctor:")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Please enter a Date")]
        [Display(Name = "Date:")]
        [Unique("DoctorId")]
        public DateTime Date { get; set; }


        public List<SelectListItem> ListDoctors{ get; set; }
    }
}