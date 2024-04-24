using DoAn_21806064393.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

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
        public ActionResult BalanceHistory(int? page)
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 1)
            {
                if (page == null) page = 1;
                var all_user = (from s in data.BalanceHistories select s).OrderByDescending(m => m.id_balance);
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


            var relatedCarts = data.Carts.Where(c => c.idacc == id);

            data.Carts.DeleteAllOnSubmit(relatedCarts);


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
                var skin = Convert.ToInt16(collection["so_skin"]);
                var price = Convert.ToDecimal(collection["gia"]);
                var hinh = collection["imageURL"];
                var xephang = collection["rank"];
                var matuongs = collection["matuong"];
                if (string.IsNullOrEmpty(name)|| string.IsNullOrEmpty(pass))
                {
                    ViewData["Error"] = "Don't empty!";
                }
                else
                {
                    s.account = name.ToString();
                    s.password = pass.ToString();
                    s.matuong = matuongs.ToString();
                    s.so_mau_mat = maumat;
                    s.so_skin = skin;
                    s.rank = xephang.ToString();
                    // Lấy giá trị khuyến mãi từ form collection
                    var khuyenMaiPercent = Convert.ToDecimal(collection["khuyenmai"]);

                    // Kiểm tra giá trị khuyến mãi và tính toán giá sau khi khuyến mãi
                    decimal giaSauKhuyenMai = price;
                    if (khuyenMaiPercent > 0)
                    {
                        // Tính giá sau khi khuyến mãi
                        giaSauKhuyenMai = price * (1 - khuyenMaiPercent / 100);
                    }

                    s.gia = giaSauKhuyenMai;
                    s.giasaukhuyenmai = giaSauKhuyenMai;
                    s.imageURL = hinh;
                    s.status = "da up";
                    data.accs.InsertOnSubmit(s);
                    data.SubmitChanges();
                    var ma_tuongs = matuongs.Split('|');
                    s.so_tuong = ma_tuongs.Length;
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
            var matuongs = collection["matuong"];
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
                s.matuong = matuongs.ToString();
                s.so_skin = skin;
                         s.status = tatus.ToString();
                s.gia = price;
                    s.imageURL = hinh;
                    data.SubmitChanges();
                    TempData["SuccessThemAcc"] = "Đã Sửa Acc Thành Công!";
                    return RedirectToAction("listacc");
                }
                return this.EditList(id);
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
                var allUsers = data.Users.OrderByDescending(acc => acc.id_user).ToList();
                return View("Index", allUsers.ToPagedList(1, 10));
            }

            var listuser = data.Users.Where(m => m.username.Contains(searchKeyword)).ToList();

            if (listuser.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy kết quả.";
                return View("Index", new List<User>().ToPagedList(1, 10)); 
            }
            var pagedList = listuser.ToPagedList(1, 10);
            return View("Index", pagedList);
        }

        [HttpPost]
        public ActionResult SearchAcc(string searchKeyword)
        {
            if (string.IsNullOrEmpty(searchKeyword))
            {
                ViewBag.Message = "Vui lòng nhập từ khóa tìm kiếm.";
                var all_acc = data.accs.OrderByDescending(acc => acc.id_acc).ToList();
                return View("listacc", all_acc.ToPagedList(1, 10));
            }

            var listacc = data.accs.Where(m => m.account.Contains(searchKeyword)).ToList();

            if (listacc.Count == 0)
            {
                ViewBag.Message = "Không tìm thấy kết quả.";
                return View("listacc", new List<acc>().ToPagedList(1, 10)); // Trả về một trang trống nếu không tìm thấy kết quả
            }
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
        [HttpPost]
        public ActionResult LockUser(int id)
        {
            var user = data.Users.FirstOrDefault(u => u.id_user == id);
            if (user != null)
            {
                
                    user.status = 1;
                    data.SubmitChanges();
                    return Json(new { success = true });
             
            }
            else
            {
                return Json(new { success = false, message = "Không tìm thấy người dùng." });
            }
        }
        [HttpPost]
        public ActionResult UnlockUser(int id)
        {
            var user = data.Users.FirstOrDefault(u => u.id_user == id);
            if (user != null)
            {
                user.status = 0;
                data.SubmitChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public ActionResult GrantPermission(int userId, int newRole)
        {
            try
            {
                var user = data.Users.FirstOrDefault(u => u.id_user == userId);
                if (user != null)
                {
                    user.roles = newRole;
                    data.SubmitChanges();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }
        public ActionResult doanhthu()
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 1)
            {
                var salesData = data.Carts.ToList();
                var totalRevenue = salesData.Sum(s => s.priceacc);
                var todayRevenue = salesData.Where(s => s.date.HasValue && s.date.Value.Date == DateTime.Today.Date).Sum(s => s.priceacc);
                var thisMonthRevenue = salesData.Where(s => s.date.HasValue && s.date.Value.Month == DateTime.Today.Month && s.date.Value.Year == DateTime.Today.Year).Sum(s => s.priceacc);
                var totalMembers = data.Users.Count();
                var totalAccOnShop = data.accs.Where(s => (s.status == "da ban" || s.status == "da up") && (s.theloai == "lol" || s.theloai == "tft")).Count();

                // Lấy thông tin biến động số dư từ cơ sở dữ liệu
                var balanceHistories = data.BalanceHistories.ToList();

                // Lọc các giao dịch thực hiện trong ngày hôm nay
                var balanceChangesToday = balanceHistories.Where(b => b.transaction_date.Date == DateTime.Today);

                // Tính tổng biến động số dư hôm nay và tổng biến động số dư
                var totalBalanceChangesToday = balanceChangesToday.Sum(b => b.amount_after - b.amount_before);
                var totalBalanceChanges = balanceHistories.Sum(b => b.amount_after - b.amount_before);

                var totalAccSold = data.accs.Where(s => s.status == "da ban").Count();

                ViewBag.SalesData = salesData.Select(s => new
                {
                    Date = s.date,
                    Price = s.priceacc
                }).ToList();

                ViewBag.TotalRevenue = totalRevenue;
                ViewBag.TodayRevenue = todayRevenue;
                ViewBag.ThisMonthRevenue = thisMonthRevenue;
                ViewBag.TotalMembers = totalMembers;
                ViewBag.TotalAccOnShop = totalAccOnShop;
                ViewBag.TotalAccSold = totalAccSold;
                ViewBag.BalanceChangesToday = totalBalanceChangesToday;
                ViewBag.TotalBalanceChanges = totalBalanceChanges;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public ActionResult AddMoney(int userId, decimal money, string reason)
        {
            try
            {
                // Lấy thông tin người dùng từ userId
                var user = data.Users.FirstOrDefault(u => u.id_user == userId);
                if (user == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy người dùng." });
                }

                // Cập nhật số tiền của người dùng
                user.price += money;

                // Lưu thay đổi vào cơ sở dữ liệu
                data.SubmitChanges();

                // Lưu lịch sử giao dịch vào cơ sở dữ liệu
                var transactionHistory = new BalanceHistory
                {
                    username = user.username,
                    amount_before = (decimal)user.price - money,
                    amount_after = (decimal)user.price,
                    current_balance = (decimal)user.price,
                    transaction_date = DateTime.Now,
                    content = $"Admin Cộng tiền: +{money}. Lý do: {reason}"
                };
                data.BalanceHistories.InsertOnSubmit(transactionHistory);

                // Lưu thay đổi vào cơ sở dữ liệu
                data.SubmitChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



        public ActionResult Logout()
        {
            Session.Remove("LoggedInUser");
            Session.Remove("UserPrice");
            return RedirectToAction("Index", "Home");
        }

    }
}