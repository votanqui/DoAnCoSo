using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DoAn_21806064393.Controllers
{
    public class EmployerController : Controller
    {
        // GET: Employer
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult userNV(int? page)
        {
            if (Session["LoggedInUser"] != null && (int)Session["UserRole"] == 3)
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
        [HttpPost]
        public ActionResult LockUser(int id)
        {
            var user = data.Users.FirstOrDefault(u => u.id_user == id);
            if (user != null)
            {
                if (user.roles == 1 )
                {
                    // Trả về thông báo lỗi khi không thể khóa tài khoản của sếp
                    return Json(new { success = false, message = "Giỡn Mặt Hả Dám Khóa Tài Khoản Sếp" });
                }
                else
                {
                    user.status = 1;
                    data.SubmitChanges();
                    return Json(new { success = true });
                }
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
        public ActionResult ChangePassword(int id, string newPassword)
        {
            try
            {
                // Truy vấn cơ sở dữ liệu để tìm người dùng cần thay đổi mật khẩu
                var user = data.Users.FirstOrDefault(u => u.id_user == id);

                // Kiểm tra xem người dùng có tồn tại không
                if (user != null)
                {
                    // Cập nhật mật khẩu mới
                    user.password = AESEncryption.Encrypt(newPassword);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    data.SubmitChanges();

                    // Trả về kết quả thành công
                    return Json(new { success = true });
                }
                else
                {
                    // Trả về kết quả thất bại nếu không tìm thấy người dùng
                    return Json(new { success = false, message = "Người dùng không tồn tại." });
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về kết quả thất bại
                return Json(new { success = false, message = ex.Message });
            }
        }
        public static class AESEncryption
        {
            private const string EncryptionKey = "yourEncryptionKey";

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

    }
}