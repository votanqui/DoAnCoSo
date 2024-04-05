using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using PagedList;

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

        public ActionResult DetailsACC(int id)
        {
            var acc = data.accs.FirstOrDefault(a => a.id_acc == id);
           
            if (acc == null)
            {
                return HttpNotFound(); // Trả về lỗi 404 nếu không tìm thấy tài khoản
            }

            if (acc.status == "da ban")
            {
                // Nếu tài khoản đã bán, chuyển hướng người dùng đến trang thông báo lỗi hoặc trang chính
                return RedirectToAction("AccountSoldOut", "Error");
            }

            return View(acc); // Hiển thị chi tiết của tài khoản
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
                // Áp dụng điều kiện tìm kiếm giá nếu cả hai biến fromPrice và toPrice được cung cấp
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