using DataAccess.Entety;
using HelthSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace HelthSystem.ViewModels.DoctorVM
{
    public class DoctorFilterVM : FilterVM<Doctor>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }
        [FilterByAttribute(DisplayName = "Email:")]
        public string Email { get; set; }
        [FilterByAttribute(DisplayName = "Adress:")]
        public string Adress { get; set; }
        [FilterByAttribute(DisplayName = "Position:")]
        public string Position { get; set; }

        public string Status { get; set; }

        [FilterDropDownAttribute(DisplayName = "Status", TargetProperty = "Status")]
        public List<SelectListItem> StatusListItems { get; set; }

        public DoctorFilterVM()
        {
            StatusListItems = new List<SelectListItem> { new SelectListItem { Text = "True", Value = "true" },
                                                                                 new SelectListItem { Text = "False", Value = "false" } 
            };
        }

        public override Expression<Func<Doctor, bool>> GenerateFilter()
        {
            return (d => (String.IsNullOrEmpty(Name) || d.User.FirstName.Contains(Name)) &&
                         (String.IsNullOrEmpty(Name) || d.User.LastName.Contains(Name)) &&
                         (String.IsNullOrEmpty(Adress) || d.User.Adress.Contains(Adress)) &&
                         (String.IsNullOrEmpty(Position) || d.Position.Contains(Position)) &&
                         (String.IsNullOrEmpty(Status) || d.User.AdminRole.ToString() == Status) &&
                         (String.IsNullOrEmpty(Email) || d.User.Email.Contains(Email)));
        }
    }
}