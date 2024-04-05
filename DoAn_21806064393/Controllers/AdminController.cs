using DoAn_21806064393.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DoAn_21806064393.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index(int ?page)
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 1)
            {
                if (page == null) page = 1;
                var all_user = (from s in data.Users select s).OrderByDescending(m => m.id_user);
                int pageSize = 8;
                int pageNum = page ?? 1;
                return View(all_user.ToPagedList(pageNum, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        public ActionResult listacc(int? page)
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 1)
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
        public ActionResult ThongKe(int? page)
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 1)
            {
                if (page == null) page = 1;
                var all_cart = (from user in data.Carts select user).OrderByDescending(m=>m.cartid);
                int pageSize = 8; 
                int pageNumber = page ?? 1;
                return View(all_cart.ToPagedList(pageNumber, pageSize));
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
        public ActionResult DeleteUser(int id)
        {
            var D_user = data.Users.FirstOrDefault(m => m.id_user == id);
            return View(D_user);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            var D_user = data.Users.Where(m => m.id_user == id).First();
            data.Users.DeleteOnSubmit(D_user);
            data.SubmitChanges();
            return RedirectToAction("index", "Admin");
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
        public ActionResult CreateList(FormCollection collection, acc s, HttpPostedFileBase file)
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

                    // Lấy giá trị khuyến mãi từ form collection
                    var khuyenMaiPercent = Convert.ToDecimal(collection["khuyenmai"]);

                    // Kiểm tra giá trị khuyến mãi và tính toán giá sau khi khuyến mãi
                    decimal giaSauKhuyenMai = price;
                    if (khuyenMaiPercent > 0)
                    {
                        // Tính giá sau khi khuyến mãi
                        giaSauKhuyenMai = price * (1 - khuyenMaiPercent / 100);
                    }

                    // Gán giá sau khi khuyến mãi vào đối tượng acc
                    s.gia = giaSauKhuyenMai;
                    s.giasaukhuyenmai = giaSauKhuyenMai;
                    s.imageURL = hinh;
                    s.status = "da up";
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
        public ActionResult EditUser(int id)
        {
            var E_acc = data.Users.First(m => m.id_user == id);
            return View(E_acc);
        }

        [HttpPost]
        public ActionResult EditUser(FormCollection collection, int id)
        {

            var s = data.Users.First(m => m.id_user == id);
            var name = collection["username"];
            var pass = collection["password"];
            var mail = collection["gmail"];
            var sotien = Convert.ToDecimal(collection["price"]);
            s.id_user = id;
            if (string.IsNullOrEmpty(name))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.username = name.ToString();
                s.password = pass.ToString();
                s.gmail = mail;         
                s.price = sotien;        
                data.SubmitChanges();
                TempData["SuccessThemUser"] = "Đã Sửa Tài Khoản Thành Công!";
                return RedirectToAction("Index");
            }
            return this.EditUser(id);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
        [HttpPost]
        public ActionResult SearchUser(string searchKeyword)
        {
            if (string.IsNullOrEmpty(searchKeyword))
            {
                ViewBag.Message = "Vui lòng nhập từ khóa tìm kiếm.";
                return View("Index", new List<User>().ToPagedList(1, 10)); // Trả về một trang trống nếu không có từ khóa tìm kiếm
            }

            var listuser = data.Users.Where(m => m.username.Contains(searchKeyword)).ToList();

            if (listuser.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy kết quả.";
                return View("Index", new List<User>().ToPagedList(1, 10)); // Trả về một trang trống nếu không tìm thấy kết quả
            }

            // Chuyển đổi danh sách thành đối tượng phân trang IPagedList<User>
            var pagedList = listuser.ToPagedList(1, 10); // Số trang và kích thước trang có thể điều chỉnh tùy ý
            return View("Index", pagedList);
        }

        [HttpPost]
        public ActionResult SearchAcc(string searchKeyword)
        {
            if (string.IsNullOrEmpty(searchKeyword))
            {
                ViewBag.Message = "Vui lòng nhập từ khóa tìm kiếm.";
                return View("listacc", new List<acc>().ToPagedList(1, 10)); // Trả về một trang trống nếu không có từ khóa tìm kiếm
            }

            var listacc = data.accs.Where(m => m.account.Contains(searchKeyword)).ToList();

            if (listacc.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy kết quả.";
                return View("listacc", new List<acc>().ToPagedList(1, 10)); // Trả về một trang trống nếu không tìm thấy kết quả
            }

            // Chuyển đổi danh sách thành đối tượng phân trang IPagedList<Acc>
            var pagedList = listacc.ToPagedList(1, 10); // Số trang và kích thước trang có thể điều chỉnh tùy ý
            return View("listacc", pagedList);
        }
        [HttpPost]
        public ActionResult UpdateKhuyenMai(int id, int khuyenMaiPercent)
        {
            try
            {
                var accToUpdate = data.accs.FirstOrDefault(a => a.id_acc == id);

                if (accToUpdate != null)
                {
                    // Kiểm tra và xử lý giá trị khuyến mãi
                    if (khuyenMaiPercent >= 0 && khuyenMaiPercent <= 100)
                    {
                        // Tính toán giá sau khi áp dụng khuyến mãi
                        decimal giaSauKhuyenMai;
                        if (khuyenMaiPercent == 0)
                        {
                            giaSauKhuyenMai = (decimal)accToUpdate.gia;
                        }
                        else
                        {
                            giaSauKhuyenMai = (decimal)accToUpdate.gia * (1 - (decimal)khuyenMaiPercent / 100);
                        }

                        // Cập nhật giá trị khuyến mãi vào cơ sở dữ liệu
                        accToUpdate.khuyenmai = khuyenMaiPercent;

                        // Cập nhật giá mới vào cơ sở dữ liệu
                        accToUpdate.giasaukhuyenmai = giaSauKhuyenMai;
                        data.SubmitChanges();

                        return Json(new { success = true, giaSauKhuyenMai = giaSauKhuyenMai });
                    }
                    else
                    {
                        // Nếu giá trị khuyến mãi không hợp lệ
                        return Json(new { success = false, error = "Giá trị khuyến mãi không hợp lệ." });
                    }
                }
                else
                {
                    // Nếu không tìm thấy tài khoản
                    return Json(new { success = false, error = "Không tìm thấy tài khoản trong cơ sở dữ liệu." });
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return Json(new { success = false, error = ex.Message });
            }
        }



    }
}