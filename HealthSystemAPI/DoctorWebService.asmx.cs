using DataAccess.Entety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataAccess.Service;
using HealthSystemAPI.Models;

namespace HealthSystemAPI
{
    /// <summary>
    /// Summary description for DoctorWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DoctorWebService : BaseWebService<Doctor,DoctorModel>
    {
        public override void PolulateItem(Doctor item, DoctorModel model)
        {
            item.Id = model.Id;
            item.UserId = model.UserId;
            item.Position = model.Position;
            item.Description = model.Description;
        }

        public override void PolulateModel(Doctor item, DoctorModel model)
        {
            model.Id = item.Id;
            model.UserId = item.UserId;
            model.Position = item.Position;
            model.Description = item.Description;
        }

        public override BaseService<Doctor> SetService()
        {
            return new DoctorService();
        }
       
    }
}
