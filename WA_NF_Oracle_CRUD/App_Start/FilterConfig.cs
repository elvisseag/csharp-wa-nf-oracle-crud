﻿using System.Web;
using System.Web.Mvc;

namespace WA_NF_Oracle_CRUD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
