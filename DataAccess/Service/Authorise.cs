using DataAccess.Entety;
using DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class Authorise
    {
        public User LoggedUser { get; private set; }

        public void Authenticate(string email, string password)
        {
            UserRepo patientRepo = new UserRepo();

            List<User> users = patientRepo.GetAll(p => p.Email == email && p.Password == password).ToList();

            LoggedUser = users.Count > 0 ? users[0] : null;

        }

    }
}
