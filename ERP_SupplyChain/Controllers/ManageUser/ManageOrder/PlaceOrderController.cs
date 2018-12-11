using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities;
using ERPEntities.Models;
using System.Configuration;

namespace ERP_SupplyChain.Controllers.ManageOder
{
   public class PlaceOrderController : Controller
    {
        ERP1DataContext db = new ERP1DataContext();
        //
        // GET: /PlaceOrder/
        public ActionResult OrderIndex()
        {
            List<Vendor> VendorList = db.Vendors.ToList();
            ViewBag.VendorList = new SelectList(VendorList, "VendorID", "VendorName");
            List<Category> CategoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryID", "CategoryName");
            return View();
        
        }

        // GET: /PlaceOrder/GetItemList
        public JsonResult GetItemList(int VendorId,int CategoryId)
        {
            //db.Configration.ProxyCreation enabled = false;
            List<Item> ItemList = db.Items.Where(x => x.VendorID == VendorId && x.CategoryID == CategoryId).ToList();
            
            return Json(ItemList, JsonRequestBehavior.AllowGet);

        }

        // GET: /PlaceOrder/GetItemDetails
        public JsonResult GetItemDetails(int id)
        {
            //db.Configration.ProxyCreation enabled = false;
            List<Item> Itemdetails = db.Items.Where(x => x.ItemID == id).ToList();
            return Json(Itemdetails, JsonRequestBehavior.AllowGet);

        }

        // POST: /PlaceOrder/saveOrder
        [HttpPost]
        public JsonResult SaveOrder(OrderVM O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ERP1DataContext dc = new ERP1DataContext())
                {
                    Order Order= new Order { OrderDate= O.OrderDate, OrderStatus = O.OrderStatus,TotalAmount = O.TotalAmount, Payment = O.Payment};
                    foreach (var i in O.OrderDetails)
                    {
                        //
                        // i.TotalAmount = 
                        Order.OrderDetails.Add(i);
                    }
                    dc.Orders.InsertOnSubmit(Order);
                    dc.SubmitChanges();
                    status = true;
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