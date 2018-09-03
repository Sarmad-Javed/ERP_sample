using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using ERPEntities.Models;

namespace ERP_SupplyChain.Controllers.ManageVendor
{
	public class ManageVendorController : Controller
	{
		//
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

		[HttpPost]
		public ActionResult AddVendor(AddVendorModel vendor)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				VendorLogic.addVendor(vendor);
			}
			return View();

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