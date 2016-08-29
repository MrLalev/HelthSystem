using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccess.Entety
{
    public class User: BaseEntety
    {
        public User()
        {
            this.Appointments = new List<Appointment>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public bool AdminRole { get; set; }

        public virtual List<Appointment> Appointments { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
