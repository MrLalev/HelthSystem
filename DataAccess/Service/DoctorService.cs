using DataAccess.Entety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Repo;

namespace DataAccess.Service
{
    public class DoctorService : BaseService<Doctor>
    {
        public override BaseRepo<Doctor> SetRepo()
        {
            return new DoctorRepo();
        }
    }
}