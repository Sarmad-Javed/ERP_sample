using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities.Models;
using ERPEntities;

namespace ERP_SupplyChain.Controllers
{
    public class SupplyChainController : Controller
    {
        ERP1DataContext dc = new ERP1DataContext();
        //
        // GET: /SupplyChain/
        public ActionResult Dashboard()
        {
            return View();
        }

        public JsonResult GetLowStock()
        {
            List<LowStockVM> List = new List<LowStockVM>();
            var data = dc.Stocks.Where(s => s.Quantity <= 10).ToList();
            foreach(var v in data)
            {
                LowStockVM S = new LowStockVM();
                S.StockID = v.StockID;
                S.ItemName = v.ItemName;
                S.Quantity = (int)v.Quantity;

                List.Add(S);
            }
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRequests()
        {
            List<RequestVM> List = new List<RequestVM>();
            var data = dc.Requests.Where(s => s.Status == "UnSeen").ToList();
            foreach (var v in data)
            {
                RequestVM R = new RequestVM();
                R.ReqID = v.RequestID;
                R.ReqText= v.ReqText;
                List.Add(R);
            }
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MarkSeen(int id)
        {
            bool status = false;
            if(id != null)
            {
                List<RequestVM> List = new List<RequestVM>();
                var data = dc.Requests.Where(s => s.RequestID == id).ToList();
                foreach (Request r in data)
                {
                    r.Status = "Seen";
                    dc.SubmitChanges();
                    status = true;
                }
                return new JsonResult { Data = new { status = status } };
            }
            return new JsonResult { Data = new { status = status } };  
        }

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

        public JsonResult GetPendingOrders()
        {
            var result = dc.Orders.Where(x => x.OrderStatus == "Pending").ToList();
            
            List<PendingOrderVM> Pending = new List<PendingOrderVM>();
            if (result != null)
            {
                foreach (var v in result)
                {
                    PendingOrderVM POrders = new PendingOrderVM();
                    POrders.OrderId = v.OrderId;
                    DateTime OrderDate = (DateTime)v.OrderDate;
                    string date = OrderDate.ToString("MM/dd/yyyy");
                    POrders.OrderDate = date;
                    POrders.TotalAmount = v.TotalAmount;
                    POrders.OrderStatus = v.OrderStatus;
                    POrders.Payment = v.Payment;

                    Pending.Add(POrders);
                }
                return Json(Pending, JsonRequestBehavior.AllowGet);
            }
            return Json(Pending, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetApprovedOrders()
        {
            var result = dc.Orders.Where(x => x.OrderStatus == "Approved").ToList();

            List<ApprovedOrderVM> Approved = new List<ApprovedOrderVM>();
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

                    Approved.Add(POrders);
                }

                return Json(Approved, JsonRequestBehavior.AllowGet);
            }
            return Json(Approved, JsonRequestBehavior.AllowGet);
        }
	}
}