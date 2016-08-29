using DataAccess;
using DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DataAccess.Service
{
    public abstract class BaseService<T> where T : BaseEntety, new()
    {
        private BaseRepo<T> repo;

        public abstract BaseRepo<T> SetRepo();

        public BaseService()
        {
            repo = SetRepo();
        }

        public void Create(T item)
        {
            repo.Create(item);
        }

        public void Edit(T item)
        {
            repo.Edit(item);
        }

        public void Delete(T item)
        {
            repo.Delete(item);
        }

        public T GetById(int id)
        {
            return repo.GetById(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter, int? page = null, int? pageSize = null)
        {
            return repo.GetAll(filter, page, pageSize);
        }

        public IQueryable<T> GetAll()
        {
            return repo.GetAll();
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            return repo.Count(filter);
        }
    }
}