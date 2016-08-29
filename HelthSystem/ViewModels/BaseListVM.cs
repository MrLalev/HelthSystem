using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelthSystem.ViewModels
{
    public class BaseListVM<T, F>
        where T : BaseEntety
        where F : FilterVM<T>
    {
        public List<T> Items { get; set; }
        public PagerVM Pager { get; set; }
        public F Filter { get; set; }
    }
}