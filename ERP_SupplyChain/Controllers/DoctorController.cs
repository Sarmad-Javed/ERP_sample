using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using ERPEntities.Models;
using ERPEntities;
using DataAccessLayer.DAL_Logic.Appointments;

namespace ERP_SupplyChain.Controllers
{
    public class DoctorController : Controller
    {
        DoctorDAL Doc = new DoctorDAL();
        List<AppointmentDetails> details = new List<AppointmentDetails>();
        
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
        public ActionResult Prescription(int id)
        {
            ViewBag.AppID = id;
            return View();
        }
    
         public JsonResult AppointmentDetails(int id)
        {
            //db.Configration.ProxyCreation enabled = false;
            List<AppointmentDetails> details = Doc.getAppDetails(id);
            
            return Json(details, JsonRequestBehavior.AllowGet);

        }

         [HttpPost]
         public JsonResult SavePrescription(PrescriptionVM P)
         {
             bool status = false;
             if (ModelState.IsValid)
             {
                 using (ERP1DataContext dc = new ERP1DataContext())
                 {
                     Prescription pres = new Prescription { AppointmentID = P.AppointmentID, DoctorID = P.DoctorID, PatientID = P.PatientID};
                     foreach (var i in P.MedDetails)
                     {
                         //
                         // i.TotalAmount = 
                         pres.Medications.Add(i);
                     }
                     dc.Prescriptions.InsertOnSubmit(pres);
                     dc.SubmitChanges();
                     var data = dc.Appointments.Where(a => a.AppointmentID == P.AppointmentID).ToList();
                     foreach (Appointment A in data)
                     {
                         //
                         // i.TotalAmount =
                         A.Status = "Prescribed";
                         dc.SubmitChanges();
                        
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

	}
}