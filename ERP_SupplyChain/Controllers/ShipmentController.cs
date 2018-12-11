using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities.Models;
using ERPEntities;

namespace ERP_SupplyChain.Controllers
{
    public class ShipmentController : Controller
    {
        ERP1DataContext dc = new ERP1DataContext();
        //
        // GET: /Shipment/
        //return the index view
        public ActionResult ShipmentIndex()
        {
            //get order awaiting delivery
            //table with the orange color subtext awaiting shipment
            List<ShipmentVM> OrderList = new List<ShipmentVM>(5);
            var order = dc.Orders.Where(x => x.OrderStatus == "Approved").Take(5);
            if(order != null)
            {
                foreach(var v in order)
                {
                    ShipmentVM s = new ShipmentVM();
                    s.OrderID = v.OrderId;
                    s.OrderStatus = v.OrderStatus;
                    DateTime OrderDate = (DateTime)v.OrderDate;
                    string date = OrderDate.ToString("MM/dd/yyyy");
                    s.OrderDate = date;

                    OrderList.Add(s);
                }
            }
            //return the list
            return View(OrderList);
        }

        //GetDeliveredOrders
        public JsonResult GetDeleiveredOrders()
        {
            List<ShipmentVM> NewArrival = new List<ShipmentVM>(5);
            var result = dc.Orders.Where(x => x.OrderStatus == "Delivered").Take(5);
            if (result != null)
            {
                foreach (var v in result)
                {
                    ShipmentVM s = new ShipmentVM();
                    s.OrderID = v.OrderId;
                    s.OrderStatus = v.OrderStatus;
                    DateTime OrderDate = (DateTime)v.OrderDate;
                    string date = OrderDate.ToString("MM/dd/yyyy");
                    s.OrderDate = date;

                    NewArrival.Add(s);
                }
                return Json(NewArrival, JsonRequestBehavior.AllowGet);
            }
            return Json(NewArrival, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetApprovedOrders()
        {
            List<ApprovedOrderVM> Awaiting = new List<ApprovedOrderVM>(5);
            var result = dc.Orders.Where(x => x.OrderStatus == "Approved").Take(5);
            if (result != null)
            {
                foreach (var v in result)
                {
                    ApprovedOrderVM s = new ApprovedOrderVM();
                    s.OrderId = v.OrderId;
                    s.OrderStatus = v.OrderStatus;
                    DateTime OrderDate = (DateTime)v.OrderDate;
                    string date = OrderDate.ToString("MM/dd/yyyy");
                    s.OrderDate = date;

                    Awaiting.Add(s);
                }
                return Json(Awaiting, JsonRequestBehavior.AllowGet);
            }
            return Json(Awaiting, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //Get Shipment/CheckOrderID
        public JsonResult CheckOrderID(int orderID)
        {
             bool status = false;
             var orders = dc.Orders.Where(x => x.OrderId == orderID).Take(5);
             if( orders != null)
                 {
                     status = true;
                    return new JsonResult { Data = new { status = status } };
                 }
                 return new JsonResult { Data = new { status = status } };
        }

        //Get DeliveredOrders
        //user enter orderID and date to confirm the delivery
        public JsonResult UpdateLog(int orderID, string orderDate)
        {
            List<string> AlertMessage = new List<string>(1);
            if(orderID != 0 && orderDate != null)
            {
                var order = from o in dc.Orders where (o.OrderId == orderID) select o;
               
                if (order != null)
                {
                    foreach (var v in order)
                    {
                        v.OrderStatus = "Delivered";
                    }
                    dc.SubmitChanges();
                    List<ShipmentVM> NewArrival = new List<ShipmentVM>(5);
                    var result = dc.Orders.Where(x => x.OrderStatus == "Delivered").ToList();
                    if (result != null)
                    {
                        foreach (var v in result)
                        {
                            ShipmentVM s = new ShipmentVM();
                            s.OrderID = v.OrderId;
                            s.OrderStatus = v.OrderStatus;
                            DateTime OrderDate = (DateTime)v.OrderDate;
                            string date = OrderDate.ToString("MM/dd/yyyy");
                            s.OrderDate = date;

                            NewArrival.Add(s);
                        }
                        return Json(NewArrival, JsonRequestBehavior.AllowGet);
                    }
                } 
            }
            AlertMessage.Add("OrderID or Date is null!");
            //return the status
            return Json(AlertMessage, JsonRequestBehavior.AllowGet);
        }

        //Get DeliveredOrders
        public ActionResult ApprovedOrders()
        {
            var result = dc.Orders.Where(x => x.OrderStatus == "Approved").ToList();

            List<ApprovedOrderVM> OrderList = new List<ApprovedOrderVM>();
            if (result != null)
            {
                foreach (var v in result)
                {
                    ApprovedOrderVM POrders = new ApprovedOrderVM();
                    POrders.OrderId = v.OrderId;
                    DateTime OrderDate = (DateTime)v.OrderDate;
                    string date = OrderDate.ToString("MM/dd/yyyy");
                    POrders.OrderDate = date;
                    POrders.TotalAmount = v.TotalAmount;
                    POrders.OrderStatus = v.OrderStatus;
                    POrders.Payment = v.Payment;

                    OrderList.Add(POrders);
                }

                return View(OrderList);
            }
            return View(ViewBag.ErrorMessage);
        }

        //Get DeliveredOrders
        public ActionResult DeliveredOrders()
        {
            var result = dc.Orders.Where(x => x.OrderStatus == "Delivered").ToList();

            List<DeliveredOrderVM> OrderList = new List<DeliveredOrderVM>();
            if (result != null)
            {
                foreach (var v in result)
                {
                    DeliveredOrderVM POrders = new DeliveredOrderVM();
                    POrders.OrderId = v.OrderId;
                    DateTime OrderDate = (DateTime)v.OrderDate;
                    string date = OrderDate.ToString("MM/dd/yyyy");
                    POrders.OrderDate = date;
                    POrders.TotalAmount = v.TotalAmount;
                    POrders.OrderStatus = v.OrderStatus;
                    POrders.Payment = v.Payment;

                    OrderList.Add(POrders);
                }

                return View(OrderList);
            }
            return View(ViewBag.ErrorMessage);
        }

        // GET: /PendingOrder/ordersDetail/id
        public ActionResult ApprovedDetails(int id, string status, string total, string date)
        {

            List<ApprovedDetailsVM> DetailList = new List<ApprovedDetailsVM>();
            var details = dc.OrderDetails.Where(x => x.OrderID == id).ToList();
            if (details != null)
            {
                foreach (var v in details)
                {
                    ApprovedDetailsVM Orderdetail = new ApprovedDetailsVM();
                    Orderdetail.ItemId = (int)v.ItemID;
                    Orderdetail.ItemName = v.ItemName;
                    Orderdetail.VendorName = v.VendorName;
                    Orderdetail.Category = v.Category;
                    Orderdetail.Quanitity = (int)v.Quantity;
                    Orderdetail.Price = (decimal)v.Price;
                    Orderdetail.TotalAmount = (decimal)v.TotalAmount;

                    DetailList.Add(Orderdetail);
                }
                ViewData["OrderId"] = id;
                ViewData["OrderStatus"] = status;
                ViewData["OrderDate"] = date;
                ViewData["GTotal"] = total;
                return View(DetailList);
            }
            return View(DetailList);

        }

        // GET: /PendingOrder/DeliveredDetails/id
        public ActionResult DeliveredDetails(int id, string status, string total, string date)
        {

            List<DeliveredDetailsVM> DetailList = new List<DeliveredDetailsVM>();
            var details = dc.OrderDetails.Where(x => x.OrderID == id ).ToList();
            if (details != null)
            {
                foreach (var v in details)
                {
                    DeliveredDetailsVM Orderdetail = new DeliveredDetailsVM();
                    Orderdetail.ItemId = (int)v.ItemID;
                    Orderdetail.ItemName = v.ItemName;
                    Orderdetail.VendorName = v.VendorName;
                    Orderdetail.Category = v.Category;
                    Orderdetail.Quanitity = (int)v.Quantity;
                    Orderdetail.Price = (decimal)v.Price;
                    Orderdetail.TotalAmount = (decimal)v.TotalAmount;

                    DetailList.Add(Orderdetail);
                }
                ViewData["OrderId"] = id;
                ViewData["OrderStatus"] = status;
                ViewData["OrderDate"] = date;
                ViewData["GTotal"] = total;
                return View(DetailList);
            }
            return View(DetailList);

        }

        //Get Item Details
        public JsonResult GetItemDetails(int orderID)
        {
            List<ItemsModel> itemList = new List<ItemsModel>();
            //get itemID
            var itemID = dc.OrderDetails.Where(x => x.OrderID == orderID).Select(x => x.ItemID).ToList();
            List<Item> ItemDetail = new List<Item>();
            foreach (var v in itemID)
            {
                //get itemDetails
               Item Item = dc.Items.Where(x => x.ItemID == v.Value).FirstOrDefault();

               ItemDetail.Add(Item);
            }
            if (ItemDetail != null)
            {
                //Add itemDetails to model
                foreach (var value in ItemDetail)
                {

                    ItemsModel item = new ItemsModel();
                    {
                        item.ItemID = value.ItemID;
                        item.CategoryID = (int)value.CategoryID;
                        item.VendorID = (int)value.VendorID;
                        item.ItemName = value.ItemName;
                        item.ExpDate = (DateTime)value.ExpDate;
                        item.MfgDate = (DateTime)value.MfgDate;
                        item.PurchasePrice = (double)value.PurchasePrice;
                        item.UnitPrice = (double)value.UnitPrice;
                        item.LeadTime = (int)value.LeadTime;
                        item.Unit_of_Measure = value.Unit_of_Measure;
                        itemList.Add(item);
                    }

                }
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
            //search for itemdetail in items
            return Json(ViewBag.ErrorMessage, JsonRequestBehavior.AllowGet);
        }

        //Get ItemQuantity
        public JsonResult GetItemQuantity(int orderID)
        {
            List<ItemQuantityVM> ItemQuantity = new List<ItemQuantityVM>();
            //get itemQuantity
            var Quantity = from d in dc.OrderDetails
                           where (d.OrderID == orderID)
                           select new
                           {
                               ItemID = d.ItemID,
                               Quantity = d.Quantity
                           };
            foreach (var v in Quantity)
            {
                //SaveStock to list
                ItemQuantityVM Q = new ItemQuantityVM();
                Q.ItemID = (int)v.ItemID;
                Q.Quantity = (int)v.Quantity;

                ItemQuantity.Add(Q);
            }

            return Json(ItemQuantity, JsonRequestBehavior.AllowGet);
        }

        //saveStock
        [HttpPost]
        public JsonResult SaveStock(StockVM stock)
        {
            bool status = false;
            if (stock.ItemDetails != null)
            {
                foreach (var value in stock.ItemDetails)
                    {
                        var data = dc.Stocks.Where(x => x.ItemID == value.ItemID).ToList();
                        if(data.Count != 0)
                        {
                            status = true;
                        }
                        else
                        {
                            Stock S = new Stock();
                            S.ItemID = value.ItemID;
                            S.CategoryID = value.CategoryID;
                            S.VendorID = value.VendorID;
                            S.ItemName = value.ItemName;
                            S.Quantity = 0;
                            S.ExpDate = value.ExpDate;
                            S.MfgDate = value.MfgDate;
                            S.PurchasePrice = value.PurchasePrice;
                            S.UnitPrice = value.UnitPrice;
                            S.LeadTime = value.LeadTime;
                            S.Unit_of_Measure = value.Unit_of_Measure;
                            string Day = DateTime.Now.Day.ToString();
                            string Month = DateTime.Now.Month.ToString();
                            string Year = DateTime.Now.Year.ToString();
                            S.AddedDay = Day;
                            S.AddedMonth = Month;
                            S.AddedYear = Year;

                            dc.Stocks.InsertOnSubmit(S);
                        }
                    }

                    dc.SubmitChanges();
                    status = true;
                
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

        //UpdateQuantity
        [HttpPost]
        public JsonResult UpdateQuantity(QuantityVM Q)
        {
            bool status = false;
            var order = dc.Orders.Where(x => x.OrderId == Q.OrderID).ToList();
            //Checkif item already exist
            if (Q.ItemQuantity != null)
            {
                foreach (var val in Q.ItemQuantity)
                {
                    var data = dc.Stocks.Where(x => x.ItemID == val.ItemID).ToList();


                    if (data != null)
                    {   //Yes increase stock quantity
                        foreach( Stock S  in data)
                        {
                            S.Quantity = S.Quantity + val.Quantity;
                            
                        }
                        //SaveStock to DB
                        dc.SubmitChanges();
                        status = true;
                    }
                    
                    //changeOrderStatus
                    foreach (Order O in order)
                    {
                        O.OrderStatus = "StockAdded";
                       
                    }
                    dc.SubmitChanges();
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

	}
}