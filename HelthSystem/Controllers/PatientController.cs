using DataAccess.Entety;
using DataAccess.Repo;
using HelthSystem.Filters;
using HelthSystem.ViewModels.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using DataAccess.Service;

namespace HelthSystem.Controllers
{
    [LogedFilter]
    public class PatientController : BaseController<User, CreateEditUserVM, DetailsUserVM, ListUserVM,UserFilterVM>
    {
        public override void PopulateModel(ListUserVM model)
        {
            UserService UserService = new UserService();
            List<User> users = UserService.GetPatients().ToList();
            
            TryUpdateModel(model);

            Expression<Func<User, bool>> filter = model.Filter.GenerateFilter();
            model.Items = UserService.GetItems(users, filter, model.Pager.CurrentPage, model.Pager.PageSize).ToList();

            int resultCount = UserService.CountItems(users,filter);
            model.Pager.PagesCount = (int)Math.Ceiling(resultCount / (double)model.Pager.PageSize);
        }

        public override void ExtraDelete(User item)
        {
            AppointmentService service = new AppointmentService();
            List<Appointment> appointments = service.GetAll(a => a.User.Id == item.Id).ToList();

            foreach (Appointment appointment in appointments)
            {
                service.Delete(appointment);
            }
        }

        //public override List<User> ListRepo(BaseRepo<User> repo)
        //{
        //    DoctorRepo doctorRepo = new DoctorRepo();
        //    UserRepo userRepo = new UserRepo();
        //    List<User> patients = userRepo.GetAll().ToList();
        //    List<Doctor> doctors = doctorRepo.GetAll().ToList();

        //    foreach (var doctor in doctors)
        //    {
        //        patients.Remove(userRepo.GetById(doctor.UserId));
        //    }

        //    return patients;
        //}

        public override void PopulateItem(User item, CreateEditUserVM model)
        {
            item.Id = model.Id;
            item.Email = model.Email;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.Adress = model.Adress;
            item.Phone = model.Phone;
            item.AdminRole = false;
        }

        public override void PopulateModel(User item, CreateEditUserVM model)
        {
            model.Id = item.Id;
            model.Email = item.Email;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.Adress = item.Adress;
            model.Phone = item.Phone;
        }

        public override void PopulateModelDelete(User item, DetailsUserVM model)
        {
            model.Id = item.Id;
            model.Email = item.Email;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.Adress = item.Adress;
            model.Phone = item.Phone;
        }

        public override BaseService<User> SetService()
        {
            return new UserService();
        }
    }
}