using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using ERPEntities.Models;

namespace ERP_SupplyChain.Controllers.ManageAttendance
{
    [SessionCheck]
	public class ManageAttendanceController : Controller
	{
		//
		AttendanceLogic AttendanceLogic = new AttendanceLogic();
		AttendanceModel AttendanceModel = new AttendanceModel();
		List<AttendanceModel> AttendanceList = new List<AttendanceModel>();
		// GET: /ManageAttendance/
		public ActionResult AddAttendance()
		{
			return View();
		}

		// GET: /ManageAttendance/ViewAttendance
		public ActionResult ViewAttendance()
		{
			AttendanceList = AttendanceLogic.getAttendanceList();
			return View(AttendanceList);
		}

		// GET: /ManageAttendance/UpdateAttendance
		public ActionResult UpdateAttendance(int id)
		{
			AttendanceModel attendance = new AttendanceModel();
			attendance = AttendanceLogic.viewAttendanceByID(id);
			return View(attendance);
		}
		//GET:/ManageAttendance/DeleteItem
		public ActionResult DeleteAttendance(int id)
		{
			AttendanceLogic.deleteAttendance(id);
			return Redirect("ViewAttendance");
		}

		// GET: /ManageAttendance/AttendanceDetails
		public ActionResult AttendanceDetails(int id)
		{

			AttendanceList = AttendanceLogic.viewAttendanceListByID(id);
			return View(AttendanceList);
		}

		[HttpPost]
		public ActionResult AddAttendance(AddAttendanceModel attendance)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				AttendanceLogic.addAttendance(attendance);
			}
			return View();

		}
		[HttpPost]
		public ActionResult UpdateAttendance(int id, AttendanceModel attendance)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				AttendanceLogic.updateAttendance(id, attendance);
			}

			return Redirect("AttendanceDetails?id=" + id);

		}
	}
}