using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public class HelthSystemDBContext<T> : DbContext
         where T : class
    {
        public HelthSystemDBContext()
            : base("name=HelthSystem.AppDBContext")
        {
        }

        public DbSet<T> Items { get; set; }
    }

}
