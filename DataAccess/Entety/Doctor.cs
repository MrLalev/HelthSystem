using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccess.Entety
{
    public class Doctor:BaseEntety
    {
        public Doctor()
        {
            this.Appointments = new List<Appointment>();
        }
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }

        public virtual List<Appointment> Appointments { get; set; }
    }
}
