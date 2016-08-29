using DataAccess;
using DataAccess.Repo;
using HelthSystem.Filters;
using HelthSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using DataAccess.Service;

namespace HelthSystem.Controllers
{ 
    [LogedFilter]
    public abstract class BaseController<T,C,D,L,F> : Controller
        where T : BaseEntety, new()
        where C : BaseWithIdVM, new()
        where D : BaseWithIdVM, new()
        where L : BaseListVM<T,F>, new()
        where F : FilterVM<T>, new()
    {
        public abstract BaseService<T> SetService();
        //public abstract List<T> ListRepo(BaseService<T> service);
        public abstract void PopulateItem(T item, C model);
        public abstract void PopulateModel(T item, C model);
        public abstract void PopulateModelDelete(T item, D model);

        public virtual void ExtraDelete(T item)
        {
        }

        public virtual void FillList(C model)
        {
        }

        public virtual void PopulateModel(L model)
        {
            BaseService<T> service = SetService();

            TryUpdateModel(model);

            Expression<Func<T, bool>> filter = model.Filter.GenerateFilter();
            model.Items = service.GetAll(filter, model.Pager.CurrentPage, model.Pager.PageSize).ToList();

            int resultCount = service.Count(filter);
            model.Pager.PagesCount = (int)Math.Ceiling(resultCount / (double)model.Pager.PageSize);
        }


        // GET: Base
        public ActionResult Index(string searchString, string searchBy)
        {
            L model = new L();
            model.Pager = new PagerVM();
            model.Filter = new F();

            model.Pager.Prefix = "Pager.";
            model.Filter.Prefix = "Filter.";
            model.Filter.Pager = model.Pager;

            PopulateModel(model);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            C model = new C();

            FillList(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(C model)
        {

            if (!this.ModelState.IsValid)
            {
                FillList(model);
                return View(model);
            }

            BaseService<T> service = SetService();
            T newItem = new T();

            PopulateItem(newItem, model);

            service.Create(newItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            BaseService<T> service = SetService();
            T item = service.GetById(id);

            D model = new D();

            PopulateModelDelete(item, model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(D model)
        {
            BaseService<T> service = SetService();
            T deletedItem = service.GetById(model.Id);

            service.Delete(deletedItem);

            ExtraDelete(deletedItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            C model = new C();
            FillList(model);

            BaseService<T> service = SetService();
            T item = service.GetById(id);

            PopulateModel(item, model);


            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(C model)
        {
            if (!this.ModelState.IsValid)
            {
                FillList(model);
                return View(model);
            }

            BaseService<T> service = SetService();
            T item = service.GetById(model.Id); ;

            PopulateItem(item, model);

            service.Edit(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {

            BaseService<T> service = SetService();
            T item = service.GetById(id);

            D model = new D();

            PopulateModelDelete(item, model);

            return View(model);
        }
    }
}