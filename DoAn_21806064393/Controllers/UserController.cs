using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BCrypt.Net;
using System.IO;

namespace DoAn_21806064393.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DataClasses1DataContext data = new DataClasses1DataContext();
        public static class AESEncryption
        {
            private const string EncryptionKey = "yourEncryptionKey"; // Thay đổi key mã hóa của bạn ở đây

            public static string Encrypt(string plainText)
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        plainText = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return plainText;
            }

            public static string Decrypt(string cipherText)
            {
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
        }
        public ActionResult DetailsUser(int id)
        {
            if (Session["LoggedInUser"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            // Ép kiểu Session["LoggedInUser"] về kiểu User
            var loggedInUser = Session["LoggedInUser"] as DoAn_21806064393.Models.User;
            if (loggedInUser.id_user != id)
            {
                return HttpNotFound();
            }
            var user = data.Users.FirstOrDefault(a => a.id_user == id);
            string decryptedPassword = AESEncryption.Decrypt(user.password);

            // Truyền mật khẩu đã giải mã vào ViewBag hoặc Model để sử dụng trong View
            ViewBag.DecryptedPassword = decryptedPassword;

            return View(user);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User obj)
        {
            var user = data.Users.FirstOrDefault(u => u.username == obj.username);

            // Tìm kiếm người dùng trong cơ sở dữ liệu với mật khẩu đã mã hóa
           

            if (user != null && AESEncryption.Decrypt(user.password) == obj.password)
            {
                Session["LoggedInUser"] = user;
                Session["UserPrice"] = user.price;
                Session["UserName"] = user.username;
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
                var existingUser = data.Users.FirstOrDefault(u => u.username == s.username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("username", "Tên tài khoản đã tồn tại.");
                }

                // Kiểm tra xem gmail đã tồn tại trong cơ sở dữ liệu chưa
                var existingEmail = data.Users.FirstOrDefault(u => u.gmail == s.gmail);
                if (existingEmail != null)
                {
                    ModelState.AddModelError("gmail", "Địa chỉ email đã được sử dụng.");
                }

                if (ModelState.IsValid)
                {
                    s.password = AESEncryption.Encrypt(pass);
                    s.username = use.ToString();

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
        [HttpPost]
        public ActionResult ThemGioHang(int accountId)
        {
            try
            {
                var loggedInUser = Session["LoggedInUser"] as User;
                var userToUpdate = data.Users.FirstOrDefault(u => u.id_user == loggedInUser.id_user);
                if (loggedInUser == null)
                {
                    return Json(new { success = false, error = "Bạn cần đăng nhập để thêm vào giỏ hàng." });
                }
                var account = data.accs.FirstOrDefault(a => a.id_acc == accountId);

                if (account != null)
                {
                    GioHang gioHangItem = new GioHang
                    {
                        idnick = account.id_acc,
                        gianick = account.giasaukhuyenmai,
                        image = account.imageURL,
                        userN=userToUpdate.username,
                        acc_count=account.account,
                        pass_word=account.password,

                    };
                    data.GioHangs.InsertOnSubmit(gioHangItem);
                    data.SubmitChanges();
                    var gioHangItems = data.GioHangs.Where(g => g.userN == userToUpdate.username).ToList();
                    decimal? total = gioHangItems.Sum(item => item.gianick ?? 0);
                    foreach (var item in gioHangItems)
                    {
                        item.Total = total;
                    }
                    data.SubmitChanges();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, error = "Không tìm thấy tài khoản." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        public ActionResult GioHang()
        {
            var loggedInUser = Session["LoggedInUser"] as User;
            if (loggedInUser == null)
            {
                return RedirectToAction("Login", "Account"); 
            }
            var giohang = data.GioHangs.Where(u => u.userN == loggedInUser.username).ToList();

            return View(giohang);
        }
        [HttpPost]
        public ActionResult ThanhToan(decimal newUserPrice, List<int> idnicks)
        {
            try
            {
                var loggedInUser = Session["LoggedInUser"] as User;

                if (loggedInUser != null)
                {
                    foreach (var idnick in idnicks)
                    {
                        var accToUpdate = data.accs.FirstOrDefault(a => a.id_acc == idnick);

                        if (accToUpdate != null)
                        {
                            if (accToUpdate.status == "da ban")
                            {
                                return Json(new { success = false, error = "Không thể mua acc đã bán." });
                            }

                            if (loggedInUser.price < accToUpdate.gia)
                            {
                                return Json(new { success = false, error = "Số tiền trong tài khoản không đủ để mua acc." });
                            }
                            accToUpdate.status = "da ban";
                            var updateCart = new Cart
                            {
                                date = DateTime.Now,
                                idacc = accToUpdate.id_acc,
                                priceacc = accToUpdate.gia,
                                sotien = loggedInUser.price - accToUpdate.gia,
                                userName = loggedInUser.username
                            };

                            data.Carts.InsertOnSubmit(updateCart);
                            var itemToRemove = data.GioHangs.FirstOrDefault(x => x.idnick == idnick);
                            if (itemToRemove != null)
                            {
                                data.GioHangs.DeleteOnSubmit(itemToRemove);
                            }
                        }
                        else
                        {
                            return Json(new { success = false, error = "Không tìm thấy tài khoản trong cơ sở dữ liệu." });
                        }
                    }
                    var userToUpdate = data.Users.FirstOrDefault(u => u.id_user == loggedInUser.id_user);
                    if (userToUpdate != null)
                    {
                        userToUpdate.price = newUserPrice;
                        data.SubmitChanges(); 
                    }
                    else
                    {
                        return Json(new { success = false, error = "Không tìm thấy thông tin người dùng trong cơ sở dữ liệu." });
                    }
                    Session["UserPrice"] = newUserPrice;

                    data.SubmitChanges();

                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, error = "Người dùng chưa đăng nhập." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
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
