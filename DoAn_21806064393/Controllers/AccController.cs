using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DoAn_21806064393.ViewModels;

namespace DoAn_21806064393.Controllers
{
    public class AccController : Controller
    {
        // GET: Acc
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Acc(int? page)
        {
            if (page == null) page = 1;

            var all_acc = (from s in data.accs
                           where s.status == "da up" && s.theloai == "lol"
                           orderby s.id_acc descending
                           select s);

            int pageSize = 10;
            int pageNum = page ?? 1;

            return View(all_acc.ToPagedList(pageNum, pageSize));
        }
        public ActionResult AccTFT(int? page)
        {
            if (page == null) page = 1;

            var all_acc = (from s in data.accs
                           where s.status == "da up" && s.theloai == "tft"
                           orderby s.id_acc descending
                           select s);

            int pageSize = 10;
            int pageNum = page ?? 1;

            return View(all_acc.ToPagedList(pageNum, pageSize));
        }
        public ActionResult DetailsACC(int id)
        {
            var acc = data.accs.FirstOrDefault(a => a.id_acc == id);
            if (acc == null)
            {
                return HttpNotFound();
            }
            if (acc.status == "da ban")
            {
                return RedirectToAction("AccountSoldOut", "Error");
            }

            var ma_tuongs = acc.matuong.Split('|');
            var so_tuong = ma_tuongs.Length;

            acc.so_tuong = so_tuong;
            data.SubmitChanges();
            var ma_tuongs_trong_Tuongs = data.Tuongs.Select(t => t.ma_tuong).ToList();
            var tuong_tuong_ung = new List<Tuong>();
            foreach (var ma_tuong in ma_tuongs)
            {
                if (ma_tuongs_trong_Tuongs.Contains(ma_tuong))
                {
                    var tuong = data.Tuongs.FirstOrDefault(t => t.ma_tuong == ma_tuong);
                    if (tuong != null)
                    {
                        tuong_tuong_ung.Add(tuong);
                    }
                }
            }

            var viewModel = new AccDetailsViewModel
            {
                Account = acc,
                Tuongs = tuong_tuong_ung
            };

            return View(viewModel);
        }


        public ActionResult AccTuong()
        {
            var all_tuong = from tt in data.Tuongs select tt;
            return View(all_tuong);
        }
        public int GetTotalAccounts()
        {
            int totalAccounts = 0;
            totalAccounts = data.accs.Count(acc => acc.status == "da up" && acc.theloai == "lol");
            return totalAccounts;
        }
        public int GetTotalAccountsTFT()
        {
            int totalAccounts = 0;
            totalAccounts = data.accs.Count(acc => acc.status == "da up" && acc.theloai == "tft");
            return totalAccounts;
        }
        [HttpPost]
        public ActionResult Search(string fromPrice, string toPrice, string searchById, string searchByChampion, string searchByRank, string searchBySkin, int? page)
        {
            var query = data.accs.Where(acc => acc.status == "da up");
            if (!string.IsNullOrEmpty(searchById))
            {
                int searchByIdInt = Convert.ToInt32(searchById);
                query = query.Where(acc => acc.id_acc == searchByIdInt);
            }
            else
            {
                if (!string.IsNullOrEmpty(fromPrice) && !string.IsNullOrEmpty(toPrice))
                {
                    var fromPriceInt = Convert.ToInt32(fromPrice);
                    var toPriceInt = Convert.ToInt32(toPrice);
                    query = query.Where(acc => acc.gia >= fromPriceInt && acc.gia <= toPriceInt);
                }
                if (!string.IsNullOrEmpty(searchByChampion))
                {
                    int searchByChampionInt = Convert.ToInt32(searchByChampion);
                    query = query.Where(acc => acc.so_tuong == searchByChampionInt);
                }
                if (!string.IsNullOrEmpty(searchByRank))
                {
                    query = query.Where(acc => acc.rank == searchByRank);
                }
                if (!string.IsNullOrEmpty(searchBySkin))
                {
                    int searchBySkinInt = Convert.ToInt32(searchBySkin);
                    query = query.Where(acc => acc.so_skin == searchBySkinInt);
                }
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            IPagedList<DoAn_21806064393.Models.acc> pagedSearchResults = query.ToPagedList(pageNumber, pageSize);
            return View("Acc", pagedSearchResults);
        }
    }
}