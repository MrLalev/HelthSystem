using DataAccess.Entety;
using HelthSystem.ViewModels.AppointmentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repo;
using HelthSystem.Models;
using HelthSystem.Filters;
using DataAccess.Service;

namespace HelthSystem.Controllers
{
    [LogedFilter]
    public class AppointmentController : BaseController<Appointment, CreateEditAppointmentVM, DetailsAppointmentVM, ListAppointmentVM,AppointmentFilterVM>
    {

        public override void FillList(CreateEditAppointmentVM model)
        {
            UserService UserService = new UserService();
            DoctorService DocService = new DoctorService();
            List<Doctor> doctors = DocService.GetAll().ToList();
            List<User> result = new List<User>();

            foreach (var item in doctors)
            {
                result.Add(UserService.GetById(item.User.Id));
            }

            model.ListDoctors = new List<SelectListItem>();
            foreach (var item in result)
            {
                if (item.Doctor.UserId != AuthenticationManager.LoggedUser.Id)
                {
                    model.ListDoctors.Add(new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName,
                        Value = item.Id.ToString()
                    });
                }

            }

            model.ListDoctors[0].Selected = true;
        }

        //public override List<Appointment> ListRepo(BaseRepo<Appointment> repo)
        //{
        //    List<Appointment> result = repo.GetAll(a=> a.User.Id == AuthenticationManager.LoggedUser.Id || a.DoctorId == AuthenticationManager.LoggedUser.Id).ToList();
        //    return result;
        //}

        public override void PopulateItem(Appointment item, CreateEditAppointmentVM model)
        {
            item.Id = model.Id;
            item.UserId= AuthenticationManager.LoggedUser.Id;
            item.DoctorId = model.DoctorId;
            item.Date = model.Date;
            item.IsApproved = "Pending";
        }

        public override void PopulateModel(Appointment item, CreateEditAppointmentVM model)
        {
            model.Id = item.Id;
            model.DoctorId = item.DoctorId;
            model.Date = item.Date;
        }

        public override void PopulateModelDelete(Appointment item, DetailsAppointmentVM model)
        {
            model.Id = item.Id;
            model.Doctor = item.Doctor;
            model.Patient = item.User;
            model.Date = item.Date;
            model.IsApproved = item.IsApproved;
        }

        public override BaseService<Appointment> SetService()
        {
            return new AppointmentService();
        }

        [HttpGet]
        public ActionResult SetAppointment(int id)
        {
            AppointmentService service = new AppointmentService();
            DetailsAppointmentVM model = new DetailsAppointmentVM();

            Appointment appointment = service.GetById(id);
            PopulateModelDelete(appointment, model);


            return View(model);
        }

        [HttpPost]
        public ActionResult SetAppointment(DetailsAppointmentVM model)
        {

            AppointmentService service = new AppointmentService();
            Appointment appointment = service.GetById(model.Id);
            appointment.IsApproved = model.IsApproved;

            service.Edit(appointment);

            return RedirectToAction("Index");
        }

        public class DeleteAppointmentVM
        {
        }
    }
}