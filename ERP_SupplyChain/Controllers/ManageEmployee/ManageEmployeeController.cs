using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using ERPEntities.Models;

namespace ERP_SupplyChain.Controllers.ManageEmployee
{
	public class ManageEmployeeController : Controller
	{
		//
		EmployeeLogic EmployeeLogic = new EmployeeLogic();
		EmployeeModel EmployeeModel = new EmployeeModel();
		List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
		// GET: /ManageEmployee/
		public ActionResult AddEmployee()
		{
			return View();
		}

		// GET: /ManageEmployee/ViewEmployee
		public ActionResult ViewEmployee()
		{
			EmployeeList = EmployeeLogic.getEmployeeList();
			return View(EmployeeList);
		}

		// GET: /ManageEmployee/UpdateEmployee
		public ActionResult UpdateEmployee(int id)
		{
			EmployeeModel employee = new EmployeeModel();
			employee = EmployeeLogic.viewEmployeeByID(id);
			return View(employee);
		}
		//GET:/ManageEmployee/DeleteItem
		public ActionResult DeleteEmployee(int id)
		{
			EmployeeLogic.deleteEmployee(id);
			return Redirect("ViewEmployee");
		}

		// GET: /ManageEmployee/EmployeeDetails
		public ActionResult EmployeeDetails(int id)
		{

			EmployeeList = EmployeeLogic.viewEmployeeListByID(id);
			return View(EmployeeList);
		}

		[HttpPost]
		public ActionResult AddEmployee(AddEmployeeModel employee)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				EmployeeLogic.addEmployee(employee);
			}
			return View();

		}
		[HttpPost]
		public ActionResult UpdateEmployee(int id, EmployeeModel employee)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				EmployeeLogic.updateEmployee(id, employee);
			}

			return Redirect("EmployeeDetails?id=" + id);

		}
	}
}