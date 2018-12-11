using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities.DataContext;
using ERPEntities.Models;
namespace ERP_SupplyChain.Controllers
{
    public class StockControllerController : Controller
    {
        ERPDataContext dc = new ERPDataContext();
        //
        // GET: /StockController/
        public ActionResult Index()
        {
            return View();
        }

        //Get Item Details
        public JsonResult GetItemDetails(int orderID)
        {
            //get itemID
            var itemID = dc.OrderDetails.Where(x => x.OrderID == orderID).Select(x => x.ItemID).ToList();
            foreach (var v in itemID)
            {
                //get itemDetails
                var ItemDetail = from i in dc.Items where (i.ItemID == v.Value) select i;
                if (ItemDetail != null)
                {
                    //Add itemDetails to model
                    foreach (var value in ItemDetail)
                    {
                        List<ItemsModel> itemList = new List<ItemsModel>();
                        ItemsModel item = new ItemsModel();
                        {
                            item.ItemID = value.ItemID;
                            item.CategoryID = (int)value.CategoryID;
                            item.VendorID = (int)value.VendorID;
                            item.ItemName = value.ItemName;
                            item.ExpDate = (DateTime)value.ExpDate;
                            item.MfgDate = (DateTime)value.MfgDate;
                            item.PurchasePrice = (double)value.PurchasePrice;
                            item.PurchasePrice = (double)value.PurchasePrice;
                            item.LeadTime = (int)value.LeadTime;
                            item.Unit_of_Measure = value.Unit_of_Measure;
                            itemList.Add(item);
                        }
                        return Json(itemList, JsonRequestBehavior.AllowGet);
                    }
                }

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
        public JsonResult SaveStock(List<ItemsModel> I)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ERPDataContext dc = new ERPDataContext())
                {

                    foreach (var value in I)
                    {
                        Stock S = new Stock();
                        S.ItemID = value.ItemID;
                        S.CategoryID = (int)value.CategoryID;
                        S.VendorID = (int)value.VendorID;
                        S.ItemName = value.ItemName;
                        S.ExpDate = value.ExpDate.ToString();
                        S.MfgDate = value.MfgDate.ToString();
                        S.PurchasePrice = (double)value.PurchasePrice;
                        S.PurchasePrice = (double)value.PurchasePrice;
                        S.LeadTime = (int)value.LeadTime;
                        S.Unit_of_Measure = value.Unit_of_Measure;
                        dc.Stocks.InsertOnSubmit(S);
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

        //UpdateQuantity
        [HttpPost]
        public JsonResult UpdateQuantity(List<ItemQuantityVM> Q, int OrderID)
        {
            bool status = false;
            var order = dc.Orders.Where(x => x.OrderId == OrderID).ToList();
            //Checkif item already exist
            if (ModelState.IsValid)
            {
                foreach (var val in Q)
                {
                    var data = dc.Stocks.Where(x => x.ItemID == val.ItemID).ToList();


                    if (data != null)
                    {   //Yes increase stock quantity
                        foreach (var v in Q)
                        {
                            Stock S = new Stock();
                            S.Quantity = S.Quantity + v.Quantity;
                            dc.Stocks.InsertOnSubmit(S);
                        }
                        //changeOrderStatus
                        foreach (var value in order)
                        {
                            Order O = new Order();
                            O.OrderStatus = "StockAdded";
                            dc.Orders.InsertOnSubmit(O);
                        }

                        //SaveStock to DB
                        dc.SubmitChanges();
                        status = true;
                    }
                    else
                    {
                        //else add new stock
                        foreach (var v in Q)
                        {
                            Stock S = new Stock();
                            S.Quantity = v.Quantity;
                            dc.Stocks.InsertOnSubmit(S);
                        }
                        //changeOrderStatus
                        foreach (var value in order)
                        {
                            Order O = new Order();
                            O.OrderStatus = "StockAdded";
                            dc.Orders.InsertOnSubmit(O);
                        }
                        //SaveStock to DB
                        dc.SubmitChanges();
                        status = true;

                    }
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