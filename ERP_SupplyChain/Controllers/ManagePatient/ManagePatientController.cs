using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using ERPEntities.Models;

namespace ERP_SupplyChain.Controllers.ManagePatient
{
	public class ManagePatientController : Controller
	{
		//
		PatientLogic PatientLogic = new PatientLogic();
		PatientModel PatientModel = new PatientModel();
		List<PatientModel> PatientList = new List<PatientModel>();
		// GET: /ManagePatient/
		public ActionResult AddPatient()
		{
			return View();
		}

		// GET: /ManagePatient/ViewPatient
		public ActionResult ViewPatient()
		{
			PatientList = PatientLogic.getPatientList();
			return View(PatientList);
		}

		// GET: /ManagePatient/UpdatePatient
		public ActionResult UpdatePatient(int id)
		{
			PatientModel patient = new PatientModel();
			patient = PatientLogic.viewPatientByID(id);
			return View(patient);
		}
		//GET:/ManagePatient/DeleteItem
		public ActionResult DeletePatient(int id)
		{
			PatientLogic.deletePatient(id);
			return Redirect("ViewPatient");
		}

		// GET: /ManagePatient/PatientDetails
		public ActionResult PatientDetails(int id)
		{

			PatientList = PatientLogic.viewPatientListByID(id);
			return View(PatientList);
		}

		[HttpPost]
		public ActionResult AddPatient(AddPatientModel patient)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				PatientLogic.addPatient(patient);
			}
			return View();

		}
		[HttpPost]
		public ActionResult UpdatePatient(int id, PatientModel patient)
		{
			if (ModelState.IsValid)
			{ //clalling BLL function
				PatientLogic.updatePatient(id, patient);
			}

			return Redirect("PatientDetails?id=" + id);

		}
	}
}