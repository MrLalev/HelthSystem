﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HelthSystem.ViewModels
{
    public abstract class FilterVM<T> : BaseFilter
         where T : BaseEntety
    {
        public abstract Expression<Func<T, bool>> GenerateFilter();
    }
}