using DataAccess.Entety;
using DataAccess.Repo;
using HelthSystem.Filters;
using HelthSystem.Models;
using DataAccess.Service;
using HelthSystem.ViewModels.DoctorVM;
using HelthSystem.ViewModels.HomeVM;
using HelthSystem.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelthSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateEditUserVM model = new CreateEditUserVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEditUserVM model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            UserService service = new UserService();
            User newItem = new User();

            newItem.Email = model.Email;
            newItem.Password = model.Password;
            newItem.FirstName = model.FirstName;
            newItem.LastName = model.LastName;
            newItem.Adress = model.Adress;
            newItem.Phone = model.Phone;

            service.Create(newItem);

            return RedirectToAction("Login");
        }


        [HttpGet]
        public ActionResult LogIn()
        {
            return View();

        }

        [HttpPost]
        public ActionResult LogIn(LogInVM login)
        {
            AuthenticationManager.Authenticate(login.Email, login.Password);

            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            else
            {
                return RedirectToAction("index", "Appointment");
            }
        }

        public ActionResult LogOut()
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Home");
        }

        [LogedFilter]
        [HttpGet]
        public ActionResult Details()
        {
            User user = AuthenticationManager.LoggedUser;

            DetailsUserVM moidel = new DetailsUserVM();

            moidel.Id = user.Id;
            moidel.FirstName = user.FirstName;
            moidel.Password = user.Password;
            moidel.Email = user.Email;
            moidel.LastName = user.LastName;
            moidel.Adress = user.Adress;
            moidel.Phone = user.Phone;

            return View(moidel);
        }

        [LogedFilter]
        [HttpGet]
        public ActionResult Edit()
        {
            User user = AuthenticationManager.LoggedUser;

            DoctorService service = new DoctorService();
            Doctor doc = service.GetById(user.Id);

            CreateEditDoctorVM model = new CreateEditDoctorVM();

            model.Id = user.Id;
            model.FirstName = user.FirstName;
            model.Password = user.Password;
            model.Email = user.Email;
            model.LastName = user.LastName;
            model.Adress = user.Adress;
            model.Phone = user.Phone;
            model.AdminRole = AuthenticationManager.LoggedUser.AdminRole;

            if (doc != null)
            {
                model.Position = doc.Position;
                model.Description = doc.Description;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CreateEditDoctorVM model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            UserService service = new UserService();
            User user = new User();

            user.Id = model.Id;
            user.Email = model.Email;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Adress = model.Adress;
            user.Phone = model.Phone;
            user.AdminRole = AuthenticationManager.LoggedUser.AdminRole;

            service.Edit(user);

            if (model.Position != null)
            {
                DoctorService DocService = new DoctorService();
                Doctor doc = new Doctor();

                doc.UserId = AuthenticationManager.LoggedUser.Id;
                doc.Position = model.Position;
                doc.Description = model.Description;

                DocService.Edit(doc);
            }

  
            AuthenticationManager.Authenticate(AuthenticationManager.LoggedUser.Email, AuthenticationManager.LoggedUser.Password);
            return RedirectToAction("Details", "Home");
        }
    }
}