using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities;
using ERPEntities.Models;
using System.Configuration;

namespace ERP_SupplyChain.Controllers.Pharmecy_Manager
{
    public class InvoiceController : Controller
    {
        ERP1DataContext dc = new ERP1DataContext();
        //
        // GET: /Invoice/
        public ActionResult InvoiceIndex(int AppID)
        {
            
            List<Category> CategoryList = dc.Categories.ToList();
            ViewBag.AppID = AppID;
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryID", "CategoryName");
            return View();

        }

        // GET: /PlaceOrder/GetItemList
        public JsonResult GetItemList(int CategoryId)
        {
            //db.Configration.ProxyCreation enabled = false;
            List<Stock> ItemList = dc.Stocks.Where(x => x.CategoryID == CategoryId).ToList();

            return Json(ItemList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetItemDetails(int id)
        {
            //db.Configration.ProxyCreation enabled = false;
            List<Stock> Itemdetails = dc.Stocks.Where(x => x.StockID == id).ToList();
            return Json(Itemdetails, JsonRequestBehavior.AllowGet);

        }

        // POST: /Invoice/saveInvoice
        [HttpPost]
        public JsonResult SaveInvoice(InvoiceVM I)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ERP1DataContext dc = new ERP1DataContext())
                {
                    Invoice invoice = new Invoice { InvoiceDate = I.InvoiceDate, TotalAmount = I.TotalAmount, InvoiceStatus = I.InvoiceStatus, Payment = I.Payment, AppointmentID = I.AppointmentID };
                    foreach (var i in I.InvoiceDetails)
                    {
                        //
                        // i.TotalAmount = 
                       invoice.InvoiceDetails.Add(i);
                    }
                    
                    dc.Invoices.InsertOnSubmit(invoice);
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