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

	}
}