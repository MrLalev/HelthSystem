using HelthSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelthSystem.Filters
{
    public class AdminFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.LoggedUser.AdminRole != true)
            {
                //filterContext.Result = new RedirectResult("/TaskManagement/Index");
                return;
            }
        }
    }
}