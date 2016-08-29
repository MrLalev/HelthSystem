using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthSystemAPI.Models
{
    public class UserModel :BaseIdModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public bool AdminRole { get; set; }
    }
}