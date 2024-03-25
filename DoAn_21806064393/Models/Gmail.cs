using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace DoAn_21806064393.Models
{
    public class Gmail
    {
        public string To{  get; set; }
        public void SendMail(string newPassword)
        {
            string subject = "KHÔI PHỤC MẬT KHẨU TÀI KHOẢN SHOPCUAQUI";
            string body = "Mật khẩu mới của bạn là: " + newPassword;

            MailMessage mc = new MailMessage(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), To);
            mc.Subject = subject;
            mc.Body = body;
            mc.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Timeout = 1000000;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            NetworkCredential nc = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["Email"].ToString(), System.Configuration.ConfigurationManager.AppSettings["Password"].ToString());
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;

            smtp.Send(mc);
        }

    }
}