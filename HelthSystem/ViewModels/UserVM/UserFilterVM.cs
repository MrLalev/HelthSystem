using DataAccess.Entety;
using HelthSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HelthSystem.ViewModels.UserVM
{
    public class UserFilterVM : FilterVM<User>
    {
        [FilterByAttribute(DisplayName = "Name:")]
        public string Name { get; set; }
        [FilterByAttribute(DisplayName = "Email:")]
        public string Email { get; set; }
        [FilterByAttribute(DisplayName = "Adress:")]
        public string Adress { get; set; }

        public override Expression<Func<User, bool>> GenerateFilter()
        {
            return (u => (String.IsNullOrEmpty(Name) || u.FirstName.Contains(Name)) &&
                         (String.IsNullOrEmpty(Name) || u.LastName.Contains(Name)) &&
                         (String.IsNullOrEmpty(Adress) || u.Adress.Contains(Adress)) &&
                         (String.IsNullOrEmpty(Email) || u.Email.Contains(Email)));
        }
    }
}