using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataAccess.Service;
using DataAccess;
using System.Linq.Expressions;
using HealthSystemAPI.Models;

namespace HealthSystemAPI
{
    /// <summary>
    /// Summary description for BaseWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public abstract class BaseWebService<T , M> : System.Web.Services.WebService where T : BaseEntety, new() where M: BaseIdModel, new()
    {
        private BaseService<T> service;

        public abstract BaseService<T> SetService();
        public abstract void PolulateItem(T item, M model);
        public abstract void PolulateModel(T item, M model);

        public virtual List<M> PopulateList(List<T> items)
        {
            List<M> models = new List<M>();

            foreach (var item in items)
            {
                M model = new M();

                PolulateModel(item, model);

                models.Add(model);
            }

            return models;
        }


        public BaseWebService()
        {
            service = SetService();
        }

        [WebMethod]
        public void Create(M model)
        {
            T item = new T();

            PolulateItem(item, model);

            service.Create(item);
        }

        [WebMethod]
        public void Edit(M model)
        {
            T item = new T();

            PolulateItem(item, model);

            service.Edit(item);
        }


        [WebMethod]
        public void Delete(M model)
        {
            T item = new T();

            PolulateItem(item, model);

            service.Delete(item);
        }


        [WebMethod]
        public M GetById(int id)
        {
            T item =  service.GetById(id);
            M model = new M();

            PolulateModel(item, model);

            return model;
        }

        //[WebMethod]
        //public IQueryable<T> GetAllFilter(Expression<Func<T, bool>> filter, int? page = null, int? pageSize = null)
        //{
        //    return service.GetAll(filter, page, pageSize);
        //}

        [WebMethod]
        public List<M> GetAll()
        {
            List<T> items =  service.GetAll().ToList();

            return PopulateList(items);
        }

        //[WebMethod]
        //public int Count(Expression<Func<T, bool>> filter)
        //{
        //    return service.Count(filter);
        //}
    }
}
