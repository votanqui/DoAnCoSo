using DoAn_21806064393.Models;
using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_21806064393.Controllers
{
    public class collaboratorsController : Controller
    {
        // GET: collaborators
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult listaccCTV(int? page)
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 2)
            {
                if (page == null) page = 1;
                var all_acc = (from s in data.accs select s).OrderByDescending(m => m.id_acc);
                int pageSize = 8;
                int pageNum = page ?? 1;
                return View(all_acc.ToPagedList(pageNum, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        public ActionResult EditListCTV(int id)
        {
            var E_acc = data.accs.First(m => m.id_acc == id);
            return View(E_acc);
        }

        [HttpPost]
        public ActionResult EditListCTV(FormCollection collection, int id)
        {

            var s = data.accs.First(m => m.id_acc == id);
            var name = collection["account"];
            var pass = collection["password"];
            var maumat = Convert.ToInt32(collection["so_mau_mat"]);
            var tuong = Convert.ToInt32(collection["so_tuong"]);
            var skin = Convert.ToInt32(collection["so_skin"]);
            var tatus = collection["status"];
            var price = Convert.ToDecimal(collection["gia"]);
            var hinh = collection["imageURL"];
            s.id_acc = id;
            if (string.IsNullOrEmpty(name))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.account = name.ToString();
                s.password = pass.ToString();
                s.so_mau_mat = maumat;
                s.so_tuong = tuong;
                s.so_skin = skin;
                s.status = tatus.ToString();
                s.gia = price;
                s.imageURL = hinh;
                data.SubmitChanges();
                TempData["SuccessThemAcc"] = "Đã Sửa Acc Thành Công!";
                return RedirectToAction("listaccCTV");
            }
            return this.EditListCTV(id);
        }
        public ActionResult CreateListCTV()
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        [HttpPost]
        public ActionResult CreateListCTV(FormCollection collection, acc s, HttpPostedFileBase file)
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 2)
            {
                var name = collection["account"];
                var pass = collection["password"];
                var maumat = Convert.ToInt16(collection["so_mau_mat"]);
                var tuong = Convert.ToInt16(collection["so_tuong"]);
                var skin = Convert.ToInt16(collection["so_skin"]);
                var price = Convert.ToDecimal(collection["gia"]);
                var hinh = collection["imageURL"];

                if (string.IsNullOrEmpty(name))
                {
                    ViewData["Error"] = "Don't empty!";
                }
                else
                {
                    s.account = name.ToString();
                    s.password = pass.ToString();
                    s.so_mau_mat = maumat;
                    s.so_tuong = tuong;
                    s.so_skin = skin;

                    // Lấy giá trị khuyến mãi từ form collection
                    var khuyenMaiPercent = Convert.ToDecimal(collection["khuyenmai"]);

                    // Kiểm tra giá trị khuyến mãi và tính toán giá sau khi khuyến mãi
                    decimal giaSauKhuyenMai = price;
                    if (khuyenMaiPercent > 0)
                    {

                        giaSauKhuyenMai = price * (1 - khuyenMaiPercent / 100);
                    }

                    s.gia = giaSauKhuyenMai;
                    s.giasaukhuyenmai = giaSauKhuyenMai;
                    s.imageURL = hinh;
                    s.status = "da up";
                    data.accs.InsertOnSubmit(s);
                    data.SubmitChanges();
                    TempData["SuccessThemAcc"] = "Đã Thêm Acc Thành Công!";
                    return RedirectToAction("listaccCTV");
                }
                return this.CreateListCTV();
            }
            else
            {
                return RedirectToAction("Login", "User"); 
            }
        }

    }
}