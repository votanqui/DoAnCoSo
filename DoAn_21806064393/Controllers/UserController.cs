using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace DoAn_21806064393.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User obj)
        {
            var user = data.Users.Where(u => u.username == obj.username && u.password == obj.password).FirstOrDefault();

            if (user != null)
            {
                Session["LoggedInUser"] = user;
                Session["UserPrice"] = user.price;
                if (user.roles == 0)
                {
                    Session["UserRole"] =0; // Người dùng thường
                }
                else if (user.roles == 1)
                {
                    Session["UserRole"] = 1; // Quản trị viên
                }
                return RedirectToAction("Index", "Home");
              

            }
            else
            {
                TempData["LoggedIn"] = false;
                ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng!";
                return View(); // Trả về view Login để hiển thị thông báo lỗi
            }


           
        }
        public ActionResult registern()
        {
            return View();
        }
        [HttpPost]
        public ActionResult registern(FormCollection collection, User s)
        {
            var use = collection["username"];
            var pass= collection["password"];
            var mail = collection["gmail"];
            var role = collection["roles"];
            var sotien = collection["price"];
            if (string.IsNullOrEmpty(use) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(mail))
            {
                ViewData["Error"] = "Vui lòng nhập đầy đủ thông tin!";
            }
            else
            {
                if (use.Length < 6)
                {
                    ModelState.AddModelError("username", "Tên tài khoản phải có ít nhất 6 ký tự.");
                }

                if (pass.Length < 8)
                {
                    ModelState.AddModelError("password", "Mật khẩu phải có ít nhất 8 ký tự.");
                }
                if (!IsValidEmail(mail))
                {
                    ModelState.AddModelError("gmail", "Địa chỉ email không hợp lệ.");
                }
                if (s.password != s.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Mật khẩu và xác nhận mật khẩu không khớp.");
                }
                if (ModelState.IsValid)
                {
                    s.username = use.ToString();
                    s.password = pass.ToString();
                    s.gmail = mail.ToString();
                    s.roles = 0;
                    s.price = 0;
                    data.Users.InsertOnSubmit(s);
                    data.SubmitChanges();
                    return RedirectToAction("Login");
                }
            }
            return View(s);
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@gmail\.com$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }

        public ActionResult Logout()
        {
            Session.Remove("LoggedInUser");
            Session.Remove("UserPrice");
            return RedirectToAction("Index", "Home");
        }

    }
}
