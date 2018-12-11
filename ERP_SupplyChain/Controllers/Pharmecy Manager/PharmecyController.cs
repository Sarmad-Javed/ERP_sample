using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities.Models;
using ERPEntities;

namespace ERP_SupplyChain.Controllers.Pharmecy_Manager
{
    public class PharmecyController : Controller
    {
        ERP1DataContext dc = new ERP1DataContext();
        //
        // GET: /Pharmacy/
        public ActionResult Dashboard()
        {
            return View();
        }
        public JsonResult GetLowStock()
        {
            List<LowStockVM> List = new List<LowStockVM>();
            var data = dc.Stocks.Where(s => s.Quantity <= 10).ToList();
            foreach (var v in data)
            {
                LowStockVM S = new LowStockVM();
                S.StockID = v.StockID;
                S.ItemName = v.ItemName;
                S.Quantity = (int)v.Quantity;

                List.Add(S);
            }
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStock()
        {
            List<LowStockVM> List = new List<LowStockVM>();
            var data = dc.Stocks.Where(s => s.AddedDay == DateTime.Now.Day.ToString()).ToList();
            foreach (var v in data)
            {
                LowStockVM S = new LowStockVM();
                S.StockID = v.StockID;
                S.ItemName = v.ItemName;
                S.Quantity = (int)v.Quantity;

                List.Add(S);
            }
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInvoice()
        {
            List<GetInvoiceVM> List = new List<GetInvoiceVM>();
            var data = dc.Invoices.Where(s => s.AddedDay == DateTime.Now.Day.ToString()).ToList();
            foreach (var v in data)
            {
                GetInvoiceVM S = new GetInvoiceVM();
                S.InvoiceID = v.InvoiceID;
                S.Total = v.TotalAmount;
                S.InvoiceDate =(DateTime) v.InvoiceDate;

                List.Add(S);
            }
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SendRequest(string Req)
        {
            bool status = false;
            if (Req != null)
            {
                Request R = new Request();
                R.ReqText = Req;
                R.Status = "UnSeen";
                string Day = DateTime.Now.Day.ToString();
                string Month = DateTime.Now.Month.ToString();
                string Year = DateTime.Now.Year.ToString();
                R.AddedDay = Day;
                R.AddedMonth = Month;
                R.AddedYear = Year;
                dc.Requests.InsertOnSubmit(R);
                dc.SubmitChanges();
                status = true;
                return new JsonResult { Data = new { status = status } };
            }
            else
            {
                status = false;
                return new JsonResult { Data = new { status = status } };
            }
            
        }

	}
}