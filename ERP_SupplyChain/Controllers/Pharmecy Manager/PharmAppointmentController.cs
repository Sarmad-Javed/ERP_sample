using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities;
using ERPEntities.Models;
using DataAccessLayer.DAL_Logic.Pharmecy;
using DataAccessLayer.DAL_Logic.Appointments;

namespace ERP_SupplyChain.Controllers.Pharmecy_Manager
{
    public class PharmAppointmentController : Controller
    {

        ERP1DataContext dc = new ERP1DataContext();
        List<AppointmentDetails> details = new List<AppointmentDetails>();
        PharmecyDAL pharm = new PharmecyDAL();
        DoctorDAL doc = new DoctorDAL();

        //
        // GET: /PharmAppointment/
        public ActionResult Appointments()
        {
            //show perscribed appointments 
            details = pharm.Appointments();
            return View(details);
        }

        public ActionResult Prescription(int Pid,int Docid,int Appid)
        {
            //show perscribed appointments 
            ViewBag.AppID = Appid;
            ViewBag.DocID = Docid;
            ViewBag.PID = Pid;
            return View();
        }
        public JsonResult AppointmentDetails(int id)
        {
            //db.Configration.ProxyCreation enabled = false;
            List<AppointmentDetails> details = doc.getAppDetails(id);

            return Json(details, JsonRequestBehavior.AllowGet);

        }

        public JsonResult MedicationDetails(int id)
        {
            //db.Configration.ProxyCreation enabled = false;
            List<MedDetails> details = pharm.getMedDetails(id);

            return Json(details, JsonRequestBehavior.AllowGet);

        }

      
	}
}