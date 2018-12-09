using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using ERPEntities.Models;
using DataAccessLayer.DAL_Logic.Appointments;

namespace ERP_SupplyChain.Controllers
{
    public class DoctorController : Controller
    {
        DoctorDAL Doc = new DoctorDAL();
        
        //
        // GET: /Doctor/
        public ActionResult Index()
        {
            return View();
        }

        //Appointment
        public ActionResult Appointments()
        {
            AppointmentDAL AppDAL = new AppointmentDAL();
            int ID = int.Parse(Session["DoctorID"].ToString());
            List<AppointmentDetails> details = Doc.getAppointmentDetails(ID);
            return View(details);
        }
	}
}