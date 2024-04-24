using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_21806064393.ViewModels
{
    public class AccDetailsViewModel
    {
        public acc Account { get; set; }
        public IEnumerable<Tuong> Tuongs { get; set; }
    }
}
