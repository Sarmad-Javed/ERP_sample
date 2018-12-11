using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using ERPEntities.Models;
using ERPEntities;

namespace ERP_SupplyChain.Controllers.ManageVendor
{
    [SessionCheck]
	public class ManageVendorController : Controller
	{
		//
        ERP1DataContext dc = new ERP1DataContext();
		VendorLogic VendorLogic = new VendorLogic();
		VendorModel VendorModel = new VendorModel();
		List<VendorModel> VendorList = new List<VendorModel>();
		// GET: /ManageVendor/
		public ActionResult AddVendor()
		{
			return View();
		}

		// GET: /ManageVendor/ViewVendor
		public ActionResult ViewVendor()
		{
			VendorList = VendorLogic.getVendorList();
			return View(VendorList);
		}

		// GET: /ManageVendor/UpdateVendor
		public ActionResult UpdateVendor(int id)
		{
			VendorModel vendor = new VendorModel();
			vendor = VendorLogic.viewVendorByID(id);
			return View(vendor);
		}
	    //GET:/ManageVendor/DeleteItem
	    public ActionResult DeleteVendor(int id)
	    {
	        VendorLogic.deleteVendor(id);
	        return Redirect("ViewVendor");
	    }

		// GET: /ManageVendor/VendorDetails
		public ActionResult VendorDetails(int id)
		{

			VendorList = VendorLogic.viewVendorListByID(id);
			return View(VendorList);
		}
        public JsonResult CheckVendor(string VendorName)
        {
            return Json(!dc.Vendors.Any(x => x.VendorName == VendorName), JsonRequestBehavior.AllowGet);
        }

		[HttpPost]
		public ActionResult AddVendor(AddVendorModel vendor)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				VendorLogic.addVendor(vendor);
			}
			return Redirect("ViewVendor");

		}
		[HttpPost]
		public ActionResult UpdateVendor(int id, VendorModel vendor)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				VendorLogic.updateVendor(id, vendor);
			}

			return Redirect("VendorDetails?id=" + id);

		}
	}
}