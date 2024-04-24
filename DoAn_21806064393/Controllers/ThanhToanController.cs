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

                            // Kiểm tra xem đối tượng Cart đã tồn tại trong cơ sở dữ liệu chưa
                            var existingCart = data.Carts.FirstOrDefault(c => c.idacc == accountId && c.userName == loggedInUser.username);
                            if (existingCart == null)
                            {
                                // Nếu không tồn tại, thì thêm mới vào cơ sở dữ liệu
                                var updateCart = new Cart
                                {
                                    date = DateTime.Now,
                                    idacc = accountId,
                                    priceacc = accToUpdate.giasaukhuyenmai,
                                    sotien = loggedInUser.price - accToUpdate.gia,
                                    userName = loggedInUser.username,
                                    taikhoan = accToUpdate.account,
                                    pass = accToUpdate.password,
                                };
                                data.Carts.InsertOnSubmit(updateCart);
                            }

                            // Cập nhật trạng thái và giá cho acc
                            accToUpdate.status = "da ban";
                            loggedInUser.price = loggedInUser.price - accToUpdate.gia;
                            Session["UserPrice"] = loggedInUser.price;

                            // Xóa đối tượng GioHangs liên quan nếu tồn tại
                            var itemToRemove = data.GioHangs.FirstOrDefault(x => x.idnick == accountId);
                            if (itemToRemove != null)
                            {
                                data.GioHangs.DeleteOnSubmit(itemToRemove);
                            }

                            // Lưu thay đổi vào cơ sở dữ liệu
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