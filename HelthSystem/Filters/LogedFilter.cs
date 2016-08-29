using HelthSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelthSystem.Filters
{
    public class LogedFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                filterContext.Result = new RedirectResult("/Home/LogIn");
                return;
            }
        }
    }
}