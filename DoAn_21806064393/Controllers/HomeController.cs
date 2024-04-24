using DoAn_21806064393.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

using static DoAn_21806064393.Controllers.UserController;
using System.Net;
using Newtonsoft.Json;
using DoAn_21806064393.ViewModels;
using System.Data.SqlClient;

namespace DoAn_21806064393.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index ()
        {
            return View();
        }
        public ActionResult ttnaptien(int id)
        {
            if (Session["LoggedInUser"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            var loggedInUser = Session["LoggedInUser"] as User;
            if (loggedInUser.id_user != id)
            {
                return HttpNotFound();
            }
            var userTheCaos = data.thecaos.Where(a => a.tenuser == loggedInUser.username)
                                           .OrderByDescending(a => a.NgayTao)
                                           .ToList();
            var userMBBankTransactions = data.mbbanks.Where(t => t.noidung.Contains(loggedInUser.username))
                                                      .OrderByDescending(t => t.ngaytao)
                                                      .ToList();

            var viewModel = new LichSuViewModels
            {
                theocaos = userTheCaos,
                mbbanks = userMBBankTransactions
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<string> KiemTraThe(thecao theCao)
        {
            try
            {
                string apiUrl = $"https://nhanthecao.vn/api/card-auto.php?type={theCao.type}&menhgia={theCao.menhgia}&seri={theCao.seri}&pin={theCao.pin}&APIKey={theCao.APIKey}&callback={theCao.callback}&content={theCao.content}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        dynamic responseData = JObject.Parse(jsonResponse);
                        return responseData.data.status;
                    }
                    else
                    {
                        return "error";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "error";
            }
        }
        [HttpPost]
        public async Task<ActionResult> napthe(string nhaMang, int menhGia, string seri, string maThe)
        {
            try
            {
                var loggedInUser = Session["LoggedInUser"] as User;
                var theCao = new thecao
                {
                    type = nhaMang,
                    menhgia = menhGia,
                    seri = seri,
                    pin = maThe,
                    NgayTao = DateTime.Now,
                    APIKey = "SHQItaDmVwAqPcEWnkgZzNUMhlYFiyJRvuorBbdLKjGOXxespCfT",
                    callback = "https://localhost:44311/Home/Index",
                    content = "NHANTHECAO_vtquine",
                    tenuser = loggedInUser.username,
                    status = "dang xu li",
                };
                data.thecaos.InsertOnSubmit(theCao);
                data.SubmitChanges();

                string responseData = await KiemTraThe(theCao);

                // Kiểm tra kết quả từ API
                if (responseData == "success")
                {
                    // Nếu thành công, cập nhật trạng thái và trả về kết quả
                    theCao.status = "thanh cong";
                    data.SubmitChanges();
                    var userToUpdate = data.Users.FirstOrDefault(u => u.id_user == loggedInUser.id_user);
                    if (userToUpdate != null)
                    {
                        userToUpdate.price += (decimal)(menhGia * 0.7);
                        data.SubmitChanges();
                        Session["UserPrice"] = userToUpdate.price;

                        var soduthecao = new BalanceHistory
                        {
                            username = loggedInUser.username,
                            amount_before = (decimal)userToUpdate.price - (decimal)(menhGia * 0.7),
                            amount_after = (decimal)userToUpdate.price,
                            current_balance = (decimal)userToUpdate.price,
                            transaction_date = DateTime.Now,
                            content = $"Nạp từ thẻ cào +{menhGia * 0.7}"
                        };
                        data.BalanceHistories.InsertOnSubmit(soduthecao);
                        data.SubmitChanges();
                    }
                    return Json(new { success = true, message = responseData });
                }
                else if (responseData == "error")
                {
                    // Xử lý khi không nhận được phản hồi từ API
                    theCao.status = "that bai";
                    data.SubmitChanges();
                    return Json(new { success = false, message = responseData });
                }
                else
                {
                    // Xử lý khi API trả về kết quả không thành công
                    theCao.status = "that bai";
                    data.SubmitChanges();
                    return Json(new { success = false, message = responseData });
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                return Json(new { success = false, message = ex.Message });
            }
        }

        private async Task<List<object>> GetTransactionsFromAPI(User loggedInUser)
        {
            List<object> transactions = new List<object>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
 
                    HttpResponseMessage response = await client.GetAsync("https://api.sieuthicode.net/historyapimbbank/a7854299b4388fab6b8e0f0e2a048079");


                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
  
                        dynamic data = JsonConvert.DeserializeObject(json);
                        foreach (var transaction in data.TranList)
                        {
                            if (transaction.creditAmount > 0 && (transaction.description.ToString().Contains("nap tien") || transaction.description.ToString().Contains("naptien")) && transaction.description.ToString().Contains(loggedInUser.username))
                            {
                                var transactionInfo = new
                                {
                                    TranId = transaction.tranId.ToString(),
                                    CreditAmount = transaction.creditAmount.ToString(),
                                    Description = transaction.description.ToString()
                                };
                                transactions.Add(transactionInfo);
                            }
                        }
                    }
                    else
                    {
                        return transactions;
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Exception while fetching data from API: " + ex.Message);
            }
            return transactions;
        }
        private async Task SaveTransactionsToDatabase(List<object> transactions, User loggedInUser)
        {
            try
            {
                bool anyTransactionsAdded = false;

                foreach (var transaction in transactions)
                {
                    var transactionObj = (dynamic)transaction;
                    if (transactionObj.Description.Contains(loggedInUser.username))
                    {
                        string tranId = transactionObj.TranId;
                        decimal creditAmount = Convert.ToDecimal(transactionObj.CreditAmount);
                        string description = transactionObj.Description;
                        DateTime currentDate = DateTime.Now;

                        var existingTransaction = data.mbbanks.FirstOrDefault(t => t.magd == tranId && t.trangthai == "Thành công");
                        if (existingTransaction != null)
                        {
                            TempData["TransactionMessage"] = "Giao dịch đã tồn tại hoặc đã được xử lý trước đó. Vui lòng kiểm tra lại.";
                            continue;
                        }

                        var newTransaction = new mbbank
                        {
                            magd = tranId,
                            sodu = creditAmount,
                            noidung = description,
                            ngaytao = currentDate,
                            taikhoan = loggedInUser.username,
                            trangthai = "Chưa xử lý"
                        };
                        data.mbbanks.InsertOnSubmit(newTransaction);

                        loggedInUser.price += creditAmount;
                        newTransaction.trangthai = "Thành công";

                        anyTransactionsAdded = true;
                        TempData["TransactionMessage"] = "Giao dịch đã được thực hiện thành công.";

                        var userToUpdate = data.Users.FirstOrDefault(u => u.id_user == loggedInUser.id_user);
                        if (userToUpdate != null)
                        {
                            userToUpdate.price = userToUpdate.price ?? 0;
                            var transactionHistory = new BalanceHistory
                            {
                                username = loggedInUser.username,
                                amount_before = userToUpdate.price ?? 0,
                                amount_after = (userToUpdate.price ?? 0) + creditAmount,
                                current_balance = (userToUpdate.price ?? 0 )+ creditAmount,
                                transaction_date = DateTime.Now,
                                content = $"Nạp từ ngân hàng +{creditAmount}"
                            };
                            data.BalanceHistories.InsertOnSubmit(transactionHistory);
                            Session["UserPrice"] = userToUpdate.price + creditAmount;
                        }
                    }
                }

                if (anyTransactionsAdded)
                {
                    data.SubmitChanges();
                }
                else
                {
                    TempData["TransactionMessage"] = "Không tìm thấy giao dịch phù hợp.Vui lòng kiểm tra lại nội dung chuyển khoản";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while saving transactions to database: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> mbbank()
        {
            try
            {
                var loggedInUser = Session["LoggedInUser"] as User;

                var transactions = await GetTransactionsFromAPI(loggedInUser);
                await SaveTransactionsToDatabase(transactions, loggedInUser);
                return Json(transactions);
            }
            catch (Exception ex)
            {
                return Json(new { error = "Exception: " + ex.Message });
            }
        }
        [HttpPost]
        public async Task<JsonResult> SendApiRequest(string valuesString)
        {
            try
            {
                // Chia chuỗi thành mảng các giá trị bằng dấu |
                string[] values = valuesString.Split('|');

                List<string> imageDataList = new List<string>();

                // Lặp qua từng giá trị trong danh sách
                foreach (var value in values)
                {
                    // Tạo URL từ giá trị hiện tại
                    string imageUrl = "https://img.yourol06.com/img/DataLienMinh/assets/champions/loadScreenPath/" + value + ".jpg";

                    using (var httpClient = new HttpClient())
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(imageUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            byte[] imageData = await response.Content.ReadAsByteArrayAsync();
                            string imageDataBase64 = Convert.ToBase64String(imageData);
                            imageDataList.Add(imageDataBase64);
                        }
                        else
                        {
                            // Trả về thông báo lỗi nếu yêu cầu không thành công
                            return Json(new { success = false, errorMessage = "Failed to fetch the image for value: " + value });
                        }
                    }
                }

                // Trả về danh sách dữ liệu hình ảnh dưới dạng JSON
                return Json(new { success = true, imageDataList = imageDataList });
            }
            catch (Exception ex)
            {
                // Trả về thông báo lỗi nếu có lỗi xảy ra trong quá trình xử lý yêu cầu
                return Json(new { success = false, errorMessage = "An error occurred while processing your request. Please try again later." });
            }
        }
        
        public ActionResult baomat()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}