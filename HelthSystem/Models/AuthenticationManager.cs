using DataAccess.Entety;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelthSystem.Models
{
    public class AuthenticationManager
    {
        public static User LoggedUser
        {
            get
            {
                Authorise authorise = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
                {
                    HttpContext.Current.Session["LoggedUser"] = new Authorise();
                }

                authorise = (Authorise)HttpContext.Current.Session["LoggedUser"];
                return authorise.LoggedUser;
            }
        }

        public static void Authenticate(string email, string password)
        {
            Authorise authorise = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedUser"] == null)
            {
                HttpContext.Current.Session["LoggedUser"] = new Authorise();
            }

            authorise = (Authorise)HttpContext.Current.Session["LoggedUser"];
            authorise.Authenticate(email, password);
        }
        public static void Logout()
        {
            HttpContext.Current.Session["LoggedUser"] = null;
        }
    }
}