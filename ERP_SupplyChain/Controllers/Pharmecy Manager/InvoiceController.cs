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
        [HttpPost]
        public JsonResult CheckQuanity(int Quantity,int id)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ERP1DataContext dc = new ERP1DataContext())
                {
                    bool status1 = dc.Stocks.Where(s => s.StockID == id).Any(s => s.Quantity < Quantity);
                    return new JsonResult { Data = new { status = status1 } };
                }
            }
            else
            {
                status = false;
                return new JsonResult { Data = new { status = status } };
            }
            
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

         [HttpPost]
        public JsonResult ChangeAppStatus(int id)
        {
            bool status = false;
             if(id != 0 )
             {
                 var data = dc.Appointments.Where(a => a.AppointmentID == id).ToList();
                 foreach(Appointment A in data)
                 {
                     A.Status = "Ref to Desk";
                 }
                 dc.SubmitChanges();
                 status = true;
                 return new JsonResult { Data = new { status = status } };
             }
            return new JsonResult { Data = new { status = status } };
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

                    string Day = DateTime.Now.Day.ToString();
                    string Month = DateTime.Now.Month.ToString();
                    string Year = DateTime.Now.Year.ToString();
                    Invoice invoice = new Invoice { InvoiceDate = I.InvoiceDate, TotalAmount = I.TotalAmount, InvoiceStatus = I.InvoiceStatus, Payment = I.Payment, AppointmentID = I.AppointmentID , AddedDay = Day ,AddedMonth = Month , AddedYear = Year};
                    foreach (var i in I.InvoiceDetails)
                    {
                        //
                        // i.TotalAmount = 
                       invoice.InvoiceDetails.Add(i);
                    }
                    dc.Invoices.InsertOnSubmit(invoice);
                    foreach (var v in I.QuantityDetails)
                    {
                        var data = dc.Stocks.Where(s => s.StockID == v.StockID).ToList();
                        foreach (Stock s in data)
                        {
                            s.Quantity = s.Quantity - v.Quantity;
                        }   
                        foreach(var item in I.QuantityDetails)
                        {
                            StockOut Sout = new StockOut();
                            Sout.StockID = item.StockID;
                            Sout.StockName = item.ItemName;
                            Sout.StockQuantity = item.Quantity;
                            Sout.StockRevenue = item.cast;
                            Sout.AddedDay = Day;
                            Sout.AddedMonth = Month;
                            Sout.AddedYear = Year;
                            dc.StockOuts.InsertOnSubmit(Sout);
                        }
                        
                    }
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