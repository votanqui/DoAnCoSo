using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_21806064393.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 1)
            {
                var all_user = from tt in data.Users select tt;
                return View(all_user);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        public ActionResult listacc()
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 1)
            {
                var all_user = from tt in data.accs select tt;

                return View(all_user);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        public ActionResult DeleteList(int id)
        {
            var D_acc = data.accs.FirstOrDefault(m => m.id_acc == id);
            return View(D_acc);
        }

        [HttpPost]
        public ActionResult DeleteList(int id, FormCollection collection)
        {
            var D_acc = data.accs.Where(m => m.id_acc == id).First();
            data.accs.DeleteOnSubmit(D_acc);
            data.SubmitChanges();
            return RedirectToAction("listacc", "Admin");
        }
        public ActionResult CreateList()
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 1)
            {
                return View();
            }
            else
            {             
                return RedirectToAction("Login", "User"); 
            }
        }
        [HttpPost]
        public ActionResult CreateList(FormCollection collection, acc s)
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 1)
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
                    s.gia = price;
                    s.imageURL = hinh;
                    data.accs.InsertOnSubmit(s);
                    data.SubmitChanges();
                    TempData["SuccessThemAcc"] = "Đã Thêm Acc Thành Công!";
                    return RedirectToAction("listacc");
                }
                return this.CreateList();
            }
            else
            {
                // Nếu không phải là vai trò 1 hoặc không đăng nhập, chuyển hướng người dùng đến trang không được phép hoặc trang đăng nhập
                // Ở đây, bạn có thể chuyển hướng đến trang thông báo lỗi hoặc trang đăng nhập
                return RedirectToAction("Login", "User");  // Điều hướng đến trang thông báo lỗi
            }
        }
        public ActionResult EditList(int id)
        {
            var E_acc = data.accs.First(m => m.id_acc == id);
            return View(E_acc);
        }

        [HttpPost]
        public ActionResult EditList(FormCollection collection, int id)
        {
            
                var s = data.accs.First(m => m.id_acc == id);
                var name = collection["account"];
                var pass = collection["password"];
                var maumat = Convert.ToInt32(collection["so_mau_mat"]);
                var tuong = Convert.ToInt32(collection["so_tuong"]);
                var skin = Convert.ToInt32(collection["so_skin"]);
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
                    s.gia = price;
                    s.imageURL = hinh;
                    data.SubmitChanges();
                    TempData["SuccessThemAcc"] = "Đã Sửa Acc Thành Công!";
                    return RedirectToAction("listacc");
                }
                return this.EditList(id);
        }

    }
}