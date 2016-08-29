using DataAccess.Entety;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelthSystem.ViewModels.AppointmentVM
{
    public class DetailsAppointmentVM : BaseWithIdVM
    {
        public Doctor Doctor { get; set; }
        public User Patient { get; set; }

        [Display(Name = "Date:")]
        public DateTime Date { get; set; }

        [Display(Name = "Approved:")]
        public string IsApproved { get; set; }  
    }
}