using DataAccess.Entety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Repo;

namespace DataAccess.Service
{
    public class AppointmentService : BaseService<Appointment>
    {
        public override BaseRepo<Appointment> SetRepo()
        {
            return new AppointmentRepo();
        }
    }
}