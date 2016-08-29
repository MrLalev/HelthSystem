using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthSystemAPI.Models
{
    public class DoctorModel : BaseIdModel
    {
        public int UserId { get; set; }

        public string Position { get; set; }

        public string Description { get; set; }

    }
}