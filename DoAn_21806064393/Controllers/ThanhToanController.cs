using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_21806064393.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        DataClasses1DataContext data = new DataClasses1DataContext();
        [HttpPost]
        public ActionResult UpdateUserPrice(decimal newUserPrice, int accountId)
        {
            try
            {
                var loggedInUser = Session["LoggedInUser"] as User;
                if (loggedInUser != null)
                {
                    var accToUpdate = data.accs.FirstOrDefault(a => a.id_acc == accountId);
                    if (accToUpdate != null)
                    {
                        if (accToUpdate.status == "da ban")
                        {
                            return Json(new { success = false, error = "Không thể mua acc đã bán." });
                        }
                        var userToUpdate = data.Users.FirstOrDefault(u => u.id_user == loggedInUser.id_user);

                        if (userToUpdate != null)
                        {
                            userToUpdate.price = newUserPrice;
                            data.SubmitChanges(); 
                            var updateCart = new Cart
                            {
                                date = DateTime.Now, 
                                idacc = accountId,
                                priceacc = accToUpdate.giasaukhuyenmai, 
                                sotien = loggedInUser.price - accToUpdate.gia, 
                                userName = loggedInUser.username 
                            };
                            data.Carts.InsertOnSubmit(updateCart);
                            data.SubmitChanges(); 
                            accToUpdate.status = "da ban";
                            loggedInUser.price = loggedInUser.price - accToUpdate.gia;
                            Session["UserPrice"] = loggedInUser.price;
                            data.SubmitChanges(); 
                            return Json(new { success = true });
                        }
                        else
                        {
                            return Json(new { success = false, error = "Không tìm thấy người dùng trong cơ sở dữ liệu." });
                        }
                    }
                    else
                    {
                        return Json(new { success = false, error = "Không tìm thấy tài khoản trong cơ sở dữ liệu." });
                    }
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
    }
}