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
    /// Summary description for AppointmentWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AppointmentWebService :BaseWebService<Appointment, AppointmentModel>
    {
        public override void PolulateItem(Appointment item, AppointmentModel model)
        {
            item.Id = model.Id;
            item.UserId = model.UserId;
            item.DoctorId = model.DoctorId;
            item.Date = model.Date;
            item.IsApproved = model.IsApproved;
        }

        public override void PolulateModel(Appointment item, AppointmentModel model)
        {
            model.Id = item.Id;
            model.UserId = item.UserId;
            model.DoctorId = item.DoctorId;
            model.Date = item.Date;
            model.IsApproved = item.IsApproved;
        }

        public override BaseService<Appointment> SetService()
        {
            return new AppointmentService();
        }
    }
}
