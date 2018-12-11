using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using ERPEntities.Models;
using ERPEntities;
using System.Data;

namespace ERP_SupplyChain.Controllers.Inventory
{
	[SessionCheck]
	public class InventoryController : Controller
	{
		//BLL object
        ERP1DataContext dc = new ERP1DataContext();
		ItemsLogic ItemLogic = new ItemsLogic();
		ItemsModel itemModel = new ItemsModel();
		public List<ItemsModel> item;
		//
		// GET: /Inventory/AddItem
		public ActionResult AddItem()
		{
         
			return View();
		}
		public ActionResult AddItems()
		{
            List<Vendor> VendorList = dc.Vendors.ToList();
            ViewBag.VendorList = new SelectList(VendorList, "VendorID", "VendorName");
            List<Category> CategoryList = dc.Categories.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "CategoryID", "CategoryName");
			return View();
		}

         public JsonResult CheckItem(string ItemName,int VendorID)
        {
            return Json(!dc.Items.Where(x => x.VendorID == VendorID).Any(x => x.ItemName == ItemName), JsonRequestBehavior.AllowGet);
        }

		// GET: /Inventory/Details/id
		public ActionResult Details(int id)
		{
			item = ItemLogic.view_ItemsByID(id);
			return View(item);
		}

		// GET: /Inventory/UpdateItem
		public ActionResult Update(int id)
		{
			item = ItemLogic.view_ItemsByID(id);
			return View(item);
		 }

		//GET:/Inventory/DeleteItem
		public ActionResult Delete(int id)
		{
			ItemLogic.DeleteItem(id);
			return Redirect("ViewItems");
		}

		// GET: /Inventory/ViewItem
		public ActionResult ViewItems()
		{
			item = ItemLogic.getItemsList();
			return View(item);          
		}

		[HttpPost]
		public ActionResult AddItem(FormCollection fc)
		{
			ItemsModel item = new ItemsModel();
			item.VendorID = int.Parse(fc["VendorID"]);
			item.CategoryID = int.Parse(fc["CategoryID"]);
			item.ItemName = fc["ItemName"];
			item.MfgDate = Convert.ToDateTime(fc["MfgDate"]).Date;
			item.ExpDate = Convert.ToDateTime(fc["ExpDate"]).Date;
			item.UnitPrice = float.Parse(fc["UnitPrice"]);
			item.PurchasePrice = float.Parse(fc["PurchasePrice"]);
			item.Unit_of_Measure = fc["UnitofMeasure"];
			item.LeadTime = int.Parse(fc["LeadTime"]);

			//clalling BLL function
			ItemLogic.addItems(item);
			return Redirect("/Inventory/ViewItems");     
		}

		[HttpPost]
		public ActionResult AddItems(ItemsModel model)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				ItemLogic.addItems(model);
			 }

            return Redirect("ViewItems");
		}

		[HttpPost]
		public ActionResult Update(int id,FormCollection fc)
		{
			ItemsModel item = new ItemsModel();
			item.ItemID = id;
			item.VendorID = int.Parse(fc["VendorID"]);
			item.CategoryID = int.Parse(fc["CategoryID"]);
			item.ItemName = fc["ItemName"];
			item.MfgDate = Convert.ToDateTime(fc["MfgDate"]).Date;
			item.ExpDate = Convert.ToDateTime(fc["ExpDate"]).Date;
			item.UnitPrice = float.Parse(fc["UnitPrice"]);
			item.PurchasePrice = float.Parse(fc["PurchasePrice"]);
			item.Unit_of_Measure = fc["UnitofMeasure"];
			item.LeadTime = int.Parse(fc["LeadTime"]);

			//clalling BLL function
			ItemLogic.UpdateItem(item);
			return Redirect("Details?id="+id);
		}
	   
	}
}