using DataAccess.Entety;
using DataAccess.Service;
using HealthSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;

namespace HealthSystemAPI
{
    /// <summary>
    /// Summary description for UserWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserWebService : BaseWebService<User, UserModel>
    {
        public override void PolulateItem(User item, UserModel model)
        {
            item.Id = model.Id;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.Password = model.Password;
            item.Email = model.Email;
            item.Phone = model.Phone;
            item.Adress = model.Adress;
            item.AdminRole = model.AdminRole;
        }

        public override void PolulateModel(User item, UserModel model)
        {
            model.Id = item.Id;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.Password = item.Password;
            model.Email = item.Email;
            model.Phone = item.Phone;
            model.Adress = item.Adress;
            model.AdminRole = item.AdminRole;
        }

        public override BaseService<User> SetService()
        {
            return new UserService();
        }

        //[WebMethod]
        //public IQueryable<User> GetItems(List<User> source, Expression<Func<User, bool>> filter, int? page = null, int? pageSize = null)
        //{
        //    UserService service = new UserService();
        //    return service.GetItems(source, filter, page, pageSize);

        //}

        //[WebMethod]
        //public IQueryable<User> GetPatients()
        //{
        //    return this.GetAllFilter(u => u.Doctor == null);
        //}

        //[WebMethod]
        //public int CountItems(List<User> source, Expression<Func<User, bool>> filter)
        //{
        //    UserService service = new UserService();
        //    return service.CountItems(source, filter);
        //}
    }
}
