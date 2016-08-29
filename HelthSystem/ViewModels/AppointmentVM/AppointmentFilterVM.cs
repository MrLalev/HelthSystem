using DataAccess.Entety;
using HelthSystem.Filters;
using HelthSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace HelthSystem.ViewModels.AppointmentVM
{
    public class AppointmentFilterVM : FilterVM<Appointment>
    {
        [FilterByAttribute(DisplayName = "Doctor name:")]
        public string DoctorName { get; set; }
        [FilterByAttribute(DisplayName = "Patient name:")]
        public string PatientName { get; set; }

        public string Status { get; set; }

        [FilterDropDownAttribute(DisplayName = "Status", TargetProperty = "Status")]
        public List<SelectListItem> StatusListItems { get; set; }

        public AppointmentFilterVM()
        {
            StatusListItems = new List<SelectListItem> { new SelectListItem { Text = "Confirmed", Value = "Confirmed" },
                                                                                 new SelectListItem { Text = "Decline", Value = "Decline" },
                                                                                 new SelectListItem { Text = "Pending", Value = "Pending" }
            };
        }

        public override Expression<Func<Appointment, bool>> GenerateFilter()
        {
            return (a => (String.IsNullOrEmpty(DoctorName) || a.Doctor.User.FirstName.Contains(DoctorName)) &&
                         (String.IsNullOrEmpty(Status) || a.IsApproved.ToLower().Equals(Status.ToLower())) &&
                         (a.User.Id == AuthenticationManager.LoggedUser.Id || a.DoctorId == AuthenticationManager.LoggedUser.Id) &&
                         (String.IsNullOrEmpty(DoctorName) || a.Doctor.User.LastName.Contains(DoctorName)) &&
                         (String.IsNullOrEmpty(PatientName) || a.User.LastName.Contains(PatientName)) &&
                         (String.IsNullOrEmpty(PatientName) || a.User.FirstName.Contains(PatientName)));
        }
    }
}