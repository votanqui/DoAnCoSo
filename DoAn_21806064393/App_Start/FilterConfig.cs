﻿using System.Web;
using System.Web.Mvc;

namespace DoAn_21806064393
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
