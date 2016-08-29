using DataAccess.Entety;
using HelthSystem.ViewModels.DoctorVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repo;
using HelthSystem.Filters;
using DataAccess.Service;

namespace HelthSystem.Controllers
{
    [LogedFilter]
    public class DoctorController : BaseController<Doctor,CreateEditDoctorVM,DetailsDoctorVM,ListDoctorsVM,DoctorFilterVM>
    {
        public override void ExtraDelete(Doctor item)
        {
            AppointmentService sevice = new AppointmentService();
            List<Appointment> appointments = sevice.GetAll(a=> a.Doctor.Id == item.UserId).ToList();

            foreach (Appointment appointment in appointments)
            {
                sevice.Delete(appointment);
            }

            UserService UserSevice = new UserService();
            UserSevice.Delete(UserSevice.GetById(item.UserId));
        }

        //public override List<Doctor> ListRepo(BaseRepo<Doctor> repo)
        //{
        //    List<Doctor> result = repo.GetAll().ToList();
        //    return result;
        //}

        public override void PopulateItem(Doctor item, CreateEditDoctorVM model)
        {

            if (item.UserId == 0)
            {
                UserService service = new UserService();
                User user = new User();

                user.Email = model.Email;
                user.Password = model.Password;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Adress = model.Adress;
                user.Phone = model.Phone;
                user.AdminRole = model.AdminRole;
                service.Create(user);

                List<User> users = service.GetAll().OrderByDescending(u=> u.Id).ToList();

                item.UserId = Convert.ToInt32(users[0].Id);
                item.Description = model.Description;
                item.Position = model.Position;

            }
            else
            {
                item.User.FirstName = model.FirstName;
                item.User.LastName = model.LastName;
                item.User.Email = model.Email;
                item.User.Password = model.Password;
                item.User.Adress = model.Adress;
                item.User.Phone = model.Phone;
                item.User.AdminRole = model.AdminRole;
                item.Description = model.Description;
                item.Position = model.Position;
            }
           
        }

        public override void PopulateModel(Doctor item, CreateEditDoctorVM model)
        {

            model.Id = item.Id;
            model.userId = item.UserId;
            model.Email = item.User.Email;
            model.Password = item.User.Password;
            model.FirstName = item.User.FirstName;
            model.LastName = item.User.LastName;
            model.Adress = item.User.Adress;
            model.Phone = item.User.Phone;
            model.AdminRole = item.User.AdminRole;
            model.Description = item.Description;
            model.Position = item.Position;
        }

        public override void PopulateModelDelete(Doctor item, DetailsDoctorVM model)
        {
            model.Id = item.Id;
            model.Email = item.User.Email;
            model.Password = item.User.Password;
            model.FirstName = item.User.FirstName;
            model.LastName = item.User.LastName;
            model.Adress = item.User.Adress;
            model.Phone = item.User.Phone;
            model.AdminRole = item.User.AdminRole;
            model.Description = item.Description;
            model.Position = item.Position;
        }

        public override BaseService<Doctor> SetService()
        {
            return new DoctorService();
        }
    }
}