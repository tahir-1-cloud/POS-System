using ABC.Customer.Domain.Configuration;
using ABC.Customer.Domain.DataConfig;
using ABC.EFCore.Repository.Edmx;
using ABC.Shared.DataConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static ABC.Customer.Domain.DataConfig.RequestSender;

namespace ABC.Customer.WebClient.Controllers
{
    public class CustomerHomePageController : Controller
    {
        private static IHttpContextAccessor httpContextAccessor;
        public CustomerHomePageController(IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
        }
        string check = "";
        string count = "";
        public IActionResult Index()
        {
            try
            {
             //     string abc =  httpContextAccessor.HttpContext.Session.GetString("userobj");

                SResponse ress = RequestSender.Instance.CallAPI("api",
                  "Inventory/ItemGet", "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    ResponseBack<List<Product>> response =
                                    JsonConvert.DeserializeObject<ResponseBack<List<Product>>>(ress.Resp);
                    if (response.Data.Count() > 0)
                    {
                        List<Product> responseObject = response.Data;
                        return View(responseObject);
                    }
                    else
                    {
                        TempData["response"] = "Server is down.";
                    }
                }

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult ProductDetailsForCustomers(int id)
        {
            try
            {
                SResponse ress = RequestSender.Instance.CallAPI("api",
             "Inventory/ItemGetByIDWithStock" + "/" + id, "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<Product>>(ress.Resp);

                    if (response.Data != null)
                    {
                        var responseObject = response.Data;
                        return View(responseObject);
                    }

                    else
                    {
                        TempData["response"] = "Server is down.";
                    }
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult AddCart(CartDetail Obj, int id)
        {
            List<CartDetail> ListCart = new List<CartDetail>();
            try
            {
                //var cart = HttpContext.Session.GetString("cart");
                //if (cart == null)
                //{
                //    var product = ProductDetails(Obj.Id);
                //    CartDetail obj = new CartDetail();
                //    Obj.ProductObj = product;
                //    Obj.Count = 1;
                //    ListCart.Add(Obj);
                //    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(ListCart));
                //}
                //else
                //{
                //    ListCart = JsonConvert.DeserializeObject<List<CartDetail>>(cart);
                //    bool check = true;
                //    for (int i = 1; i < ListCart.Count; i++)
                //    {
                //        if (ListCart[i].ProductObj.Id == Obj.Id)
                //        {
                //            ListCart[i].Count++;
                //            check = false;
                //        }
                //    }
                //    if (check)
                //    {
                //        Obj.ProductObj = ProductDetails(id);
                //        ListCart.Add(Obj);
                //    }
                //    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(ListCart));
                // }

                //  return Ok(ListCart.Count);
                Obj.UserId = 1;
                var body = JsonConvert.SerializeObject(Obj);
                // var body = sr.Serialize(obj);
                SResponse resp = RequestSender.Instance.CallAPI("api", "Customer/AddToCart", "POST", body);
                if (resp.Status && (resp.Resp != null) && (resp.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<InventoryStock>>(resp.Resp);
                    if (response.Status == 13)
                    {
                        TempData["ErrorMsg"] = "Quantity Out of Stock";
                        return RedirectToAction("ProductDetailsForCustomers",new { id= Obj.Id});
                    }
                    TempData["Msg"] = "Success";
                    return RedirectToAction("GenerateOrder");
                }
                else
                {
                    TempData["Msg"] = resp.Resp + " " + "Unable To Updates";
                    return RedirectToAction("#");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult DeleteItemCart(int? id)
        {
            try
            {
                SResponse ress = RequestSender.Instance.CallAPI("api",
             "Customer/DeleteCartItemById" + "/" + id, "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<CartDetail>>(ress.Resp);
                    return Json(true);
                }
                return Json(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult GetStockById(int? id)
        {
            InventoryStock product = new InventoryStock();
            try
            {
                SResponse ress = RequestSender.Instance.CallAPI("api",
             "Customer/GetStockById" + "/" + id, "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<InventoryStock>>(ress.Resp);

                    if (response.Data != null)
                    {
                        var responseObject = response.Data;
                        return Json(responseObject);
                    }

                    else
                    {
                        TempData["response"] = "Server is down.";
                    }
                }
                return Json(null);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult RemoveItemFromCart(int? id)
        {
            InventoryStock product = new InventoryStock();
            try
            {
                SResponse ress = RequestSender.Instance.CallAPI("api",
             "Customer/RemoveItemFromCart" + "/" + id, "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<InventoryStock>>(ress.Resp);

                    return Json(true);
                }
                return Json(null);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult AdddItemFromCart(int? id)
        {
            InventoryStock product = new InventoryStock();
            try
            {
                SResponse ress = RequestSender.Instance.CallAPI("api",
             "Customer/AddItemInCart" + "/" + id, "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<InventoryStock>>(ress.Resp);

                    return Json(true);
                }
                return Json(null);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult GetTotalCart(int? id)
        {
     
            try
            {
                SResponse ress = RequestSender.Instance.CallAPI("api",
             "Customer/GetTotalCart" , "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<List<CartDetail>>>(ress.Resp);

                    if (response.Data != null)
                    {
                        var responseObject = response.Data;
                        return Json(responseObject);
                    }

                    else
                    {
                        TempData["response"] = "Server is down.";
                    }
                }
                return Json(null);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private Product ProductDetails(int? id)
        {
            Product product = new Product();
            try
            {
                SResponse ress = RequestSender.Instance.CallAPI("api",
             "Inventory/ItemGetByIDWithStock" + "/" + id, "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<Product>>(ress.Resp);

                    if (response.Data != null)
                    {
                        var responseObject = response.Data;
                        return responseObject;
                    }

                    else
                    {
                        TempData["response"] = "Server is down.";
                    }
                }
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public IActionResult confirmorder( CustomerOrder customer)
        {

            List<CustomerOrder> ListCart = new List<CustomerOrder>();
            try
            {
                customer.UserId = 1;
                customer.AdminStatus = false;
                customer.Delivered = false;
                var body = JsonConvert.SerializeObject(customer);
                SResponse resp = RequestSender.Instance.CallAPI("api", "Customer/SaveCustomerOrder", "POST", body);
                if (resp.Status && (resp.Resp != null) && (resp.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<CustomerOrder>>(resp.Resp);
                    return Json(response.Data);
                }
                else
                {
                    TempData["Msg"] = resp.Resp + " " + "Unable To Updates";
                    return RedirectToAction("#");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
        public IActionResult ListOfCart(int? id)
        {
            try
            {
                id = 1;
                SResponse resp = RequestSender.Instance.CallAPI("api", "Customer/GetUserCartById/" + id, "GET");
                if (resp.Status && (resp.Resp != null) && (resp.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<List<CartDetail>>>(resp.Resp);
                    return View(response.Data);
                }
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
     
        //public IActionResult ListCart()
        //{
        //    var cart = HttpContext.Session.GetString("cart");
        //    if (cart != null)
        //    {
        //        List<CartDetail> DataCart = JsonConvert.DeserializeObject<List<CartDetail>>(cart);
        //        if (DataCart.Count > 0)
        //        {
        //            ViewBag.CartBag = DataCart.Count;
        //            return View();
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}

        //public IActionResult AddtoCart(Product pro)
        //{
        //    // var currentCart = HttpContext.
        //    try
        //    {

        //        SResponse ress = RequestSender.Instance.CallAPI("api",
        //        "Inventory/ItemGet", "GET");
        //        if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
        //        {
        //            ResponseBack<List<Product>> response =
        //                               JsonConvert.DeserializeObject<ResponseBack<List<Product>>>(ress.Resp);
        //            if (response.Data.Count() > 0)
        //            {
        //                List<Product> ObjProduct = response.Data;
        //                CartDetail ObjCartDetail = null;
        //                List<CartDetail> ObjListCart = new List<CartDetail>();
        //                for (int i = 0; i < ObjProduct.Count; i++)
        //                {
        //                    ObjCartDetail = new CartDetail();
        //                    ObjCartDetail.Name = ObjProduct[i].Name;
        //                    ObjCartDetail.UnitCharge = ObjProduct[i].UnitCharge;
        //                    ObjCartDetail.ImagePath = ObjProduct[i].ItemImageByPath;
        //                    ObjListCart.Add(ObjCartDetail);
        //                }
        //            }
        //            else
        //            {
        //                TempData["response"] = "Invalid Request.";
        //                return null;
        //            }
        //        }
        //        else
        //        {
        //            TempData["response"] = "Server not responding.";
        //            return null;
        //        }
        //        return RedirectToAction();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public IActionResult CartCheck(CartDetail cartDetail)
        //{
        //    HttpContext.Session.SetString("Cart", "null");
        //    check = HttpContext.Session.GetString("Cart");

        //    string num = "1";
        //    HttpContext.Session.SetString("Count", num);
        //    count = HttpContext.Session.GetString("Count");
        //    try
        //    {
        //        //check = ;
        //        List<CartDetail> li = new List<CartDetail>();
        //        if (HttpContext.Session.GetString("Cart") == "null")
        //        {
        //            li.Add(cartDetail);
        //            check = li.ToString();
        //            ViewBag.cart = li.Count();
        //            HttpContext.Session.SetString("Cart", li.ToString());
        //            var getcount = HttpContext.Session.GetString("Count");
        //            var Json = JsonConvert.SerializeObject(HttpContext.Session.GetString("Cart"));
        //            if (Json != null)
        //            {
        //                List<CartDetail> list = JsonConvert.DeserializeObject<List<CartDetail>>(Json);
        //            }
        //        }
        //        else
        //        {


        //        }
        //        return RedirectToAction("Index", "Home");
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public IActionResult OrderHistory()
        {
            try
            {
               var id = 1;
                SResponse resp = RequestSender.Instance.CallAPI("api", "Customer/GetUserOrderFromCart/" + id, "GET");
                if (resp.Status && (resp.Resp != null) && (resp.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<List<CartDetail>>>(resp.Resp);
                    return View(response.Data);
                }
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IActionResult mail()
        {
            return View();
        }
        public IActionResult GenerateOrder(int? id)
          {
            try
            {
                
                
                id = 1;
                SResponse resp = RequestSender.Instance.CallAPI("api", "Customer/GetUserCartById/" + id, "GET");
                if (resp.Status && (resp.Resp != null) && (resp.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<List<CartDetail>>>(resp.Resp);
                    return View(response.Data);
                }
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                SResponse ress = RequestSender.Instance.CallAPI("api",
               "Inventory/ItemGet", "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<List<Product>>>(ress.Resp);

                    if (response.Data != null)
                    {
                        var responseObject = response.Data;
                        return Json(responseObject);
                    }

                    else
                    {
                        TempData["response"] = "Server is down.";
                    }
                }
                return Json(null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IActionResult GetCart(int? id)
        {
            try
            {

                id = 1;
                SResponse resp = RequestSender.Instance.CallAPI("api", "Customer/GetUserCartById/" + id, "GET");
                if (resp.Status && (resp.Resp != null) && (resp.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<List<CartDetail>>>(resp.Resp);
                    //return View(response.Data);
                    return Json(response.Data);
                }
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IActionResult AddToCartFromMainScreen(int id)
        {
            CartDetail obj = new CartDetail();
            try
            {
                obj.Id = id;
                obj.UserId = 1;
                var body = JsonConvert.SerializeObject(obj);
                // var body = sr.Serialize(obj);
                SResponse resp = RequestSender.Instance.CallAPI("api", "Customer/AddToCartFromScreenAPI", "POST", body);
                if (resp.Status && (resp.Resp != null) && (resp.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<InventoryStock>>(resp.Resp);
                    if (response.Status == 13)
                    {
                        TempData["ErrorMsg"] = "Quantity Out of Stock";
                        return RedirectToAction("ProductDetailsForCustomers", new { id = obj.Id });
                    }
                    TempData["Msg"] = "Success";
                    return RedirectToAction("GenerateOrder");
                }
                else
                {
                    TempData["Msg"] = resp.Resp + " " + "Unable To Updates";
                    return RedirectToAction("#");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IActionResult PreviousOrder(int id, CustomerOrder ord)
        {
            try
            {
                string userData = httpContextAccessor.HttpContext.Session.GetString("userobj");
                if (!string.IsNullOrEmpty(userData))
                {
                    AspNetUser userDto = JsonConvert.DeserializeObject<AspNetUser>(userData);
                    SResponse ress = RequestSender.Instance.CallAPI("api",
                    "Customer/GetUserOrderFromCart" + "/" + userDto.Id, "GET");
                    if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                    {
                        var response = JsonConvert.DeserializeObject<ResponseBack<List<CustomerOrder>>>(ress.Resp);
                        if (response.Data != null)
                        {
                            var responseObject = response.Data.ToList().GroupBy(x => x.OrderId).Select(i => i.FirstOrDefault()).ToList();
                            return View(responseObject);
                        }
                        else
                        {
                            TempData["response"] = "No Order Exists.";
                            List<CustomerOrder> obj2 = new List<CustomerOrder>();
                            return View(obj2);
                        }
                    }
                }
                else
                {
                    TempData["response"] = "Session Expired";
                    return RedirectToAction("Login","Account");
                }
                List<CustomerOrder> obj = new List<CustomerOrder>();
                return View(obj);
            }
            catch (Exception ex)
            {
                TempData["response"] = ex.Message + "Error Occured.";
                return View();
            }
        }
        public IActionResult OrderDetails(string id)
        {
            try
            {             
                SResponse ress = RequestSender.Instance.CallAPI("api",
                "Customer/GetUserCartByAdminApproval" + "/" + id, "GET");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<List<CartDetail>>>(ress.Resp);
                    if (response.Data != null)
                    {
                        var responseObject = response.Data.ToList();
                        return View(responseObject);
                    }
                    else
                    {
                        TempData["response"] = "No Order Detail Exists.";
                        List<CartDetail> obj2 = new List<CartDetail>();
                        return View(obj2);
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["response"] = ex.Message + "Error Occured.";
                return View();
            }
        }



        [HttpPost]
        public async Task<string> OrderMail(string id)
        {
            try
            {           
                SResponse ress = RequestSender.Instance.CallAPI("api",
                "Customer/OrderMailReminder" + "/" + id, "Post");
                if (ress.Status && (ress.Resp != null) && (ress.Resp != ""))
                {
                    var response = JsonConvert.DeserializeObject<ResponseBack<List<CustomerOrder>>>(ress.Resp);
                    if (response.Data != null)
                    {
                        var responseObject = response.Data.ToList();                
                        return "true";
                    }
                    else
                    {
                        TempData["response"] = "No Order Detail Exists.";       
                        return "No Order Detail Exists";
                    }
                }        
                return "false";
            }
            catch (Exception ex)
            {
                TempData["response"] = ex.Message + "Error Occured.";
                return ex.Message + "Error Occured.";
            }
        }

    }
}
