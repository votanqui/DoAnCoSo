using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DoAn_21806064393.Controllers
{
    public class GmailController : Controller
    {
        // GET: Gmail
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send( Gmail gmail)
        {
            // Kiểm tra xem email có phải là địa chỉ Gmail hợp lệ không
            if (!IsGmailAddress(gmail.To))
            {
                ViewBag.Message = "Địa chỉ email không phải là địa chỉ Gmail hợp lệ.";
                return View();
            }

            string newPassword = GenerateRandomPassword();
            bool sendSuccess = false;
            // Kiểm tra xem địa chỉ email đã gửi có tồn tại trong cơ sở dữ liệu hay không
            var user = data.Users.FirstOrDefault(u => u.gmail == gmail.To);
            if (user != null)
            {
                // Cập nhật mật khẩu mới vào cơ sở dữ liệu cho người dùng tương ứng
                user.password = newPassword;
                data.SubmitChanges();

                // Gửi email chứa mật khẩu mới cho người dùng
                gmail.SendMail(newPassword);

                TempData["SuccessMessage"] = "Mật khẩu mới đã được gửi thành công!";
                return RedirectToAction("Login", "User");
            }
            else
            {
                ViewBag.Message = "Địa chỉ email không tồn tại trong hệ thống.";
                return View();
            }         
        }
        private bool IsGmailAddress(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false; // Trả về false nếu email rỗng
            }

            string pattern = @"^[a-zA-Z0-9_.+-]+@gmail\.com$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
        }
        private string GenerateRandomPassword()
        {
            // Tạo mật khẩu ngẫu nhiên (ví dụ: 6 ký tự số)
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}