using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities.Models;
using ERPEntities;
namespace ERP_SupplyChain.Controllers.ManageOrder
{
    public class PendingOrderController : Controller
    {
        ERP1DataContext dc = new ERP1DataContext();
        //
        // GET: /PendingOrder/orders
        public ActionResult Orders()
        {
            var result = dc.Orders.Where(x => x.OrderStatus == "Pending").ToList();
            
            List<PendingOrderVM> OrderList = new List<PendingOrderVM>();
            if(result != null)
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
                    POrders.Payment= v.Payment;

                    OrderList.Add(POrders);
                }
                    
                return View(OrderList);
            }
            return View(ViewBag.ErrorMessage);
        }

        // GET: /PendingOrder/ordersDetail/id
        public ActionResult OrderDetails(int id,string status,string total, string date)
        {
            
            List<OrderDetailVM> DetailList = new List<OrderDetailVM>();
            var details = dc.OrderDetails.Where(x => x.OrderID == id).ToList();
            if (details != null)
            {
                foreach(var v in details)
                {
                    OrderDetailVM Orderdetail = new OrderDetailVM();
                     Orderdetail.ItemId= (int)v.ItemID;
                     Orderdetail.ItemName = v.ItemName;
                     Orderdetail.VendorName = v.VendorName;
                     Orderdetail.Category = v.Category;
                     Orderdetail.Quanitity= (int)v.Quantity;
                     Orderdetail.Price =(decimal) v.Price;
                     Orderdetail.TotalAmount = (decimal) v.TotalAmount;

                     DetailList.Add(Orderdetail); 
                }
                ViewData["OrderId"] = id;
                ViewData["OrderStatus"]  = status;
                 ViewData["OrderDate"] = date;
                 ViewData["GTotal"] = total;
                return View(DetailList);
            }
            return View(DetailList);
            
         }

      
        // GET: /PendingOrder/ordersDetail/id
        public JsonResult ApproveOrder(int OrderID)
        {

            string status = null;
            var order = from o in dc.Orders where (o.OrderId == OrderID) select o;
            if (order != null)
            {
                foreach (var v in order)
                {
                    v.OrderStatus = "Approved";
                    v.Payment = "Paid";
                }
                dc.SubmitChanges();
                status = "success"; 
            }
            else
            {
                status="failed";
            }
            return Json(status, JsonRequestBehavior.AllowGet);
            
        }      
    }
}