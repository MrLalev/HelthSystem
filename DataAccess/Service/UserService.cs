using DataAccess.Entety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Repo;
using System.Linq.Expressions;

namespace DataAccess.Service
{
    public class UserService : BaseService<User>
    {
        public override BaseRepo<User> SetRepo()
        {
            return new UserRepo();
        }

        public IQueryable<User> GetItems(List<User> source, Expression<Func<User, bool>> filter, int? page = null, int? pageSize = null)
        {
            UserRepo repo = new UserRepo();
            return repo.GetItems(source,filter,page,pageSize);
            
        }

        public IQueryable<User> GetPatients()
        {
            return this.GetAll(u => u.Doctor == null);
        }

        public int CountItems(List<User> source, Expression<Func<User, bool>> filter)
        {
            UserRepo repo = new UserRepo();
            return repo.CountItems(source, filter);
        }
    }
}