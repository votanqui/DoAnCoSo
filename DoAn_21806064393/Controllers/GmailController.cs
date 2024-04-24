using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace DoAn_21806064393.Controllers
{
    public class GmailController : Controller
    {
        // GET: Gmail
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
        public ActionResult Send() { return View(); }
        [HttpPost]
        public ActionResult Send(Gmail gmail)
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
                user.password = AESEncryption.Encrypt(newPassword);
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