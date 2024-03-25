using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace DoAn_21806064393.Controllers
{
    public class AccController : Controller
    {
        // GET: Acc
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Acc()
        {
            var all_acc = from tt in data.accs select tt;
            return View(all_acc);
        }
    }
}