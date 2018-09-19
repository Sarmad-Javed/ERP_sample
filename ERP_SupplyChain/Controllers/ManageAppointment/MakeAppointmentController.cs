using System;
using System.Collections.Generic;
using BusinessLogicLayer;
using ERPEntities.Models;
using ERPEntities.DataContext;
using DataAccessLayer;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities;
using System.Globalization;




namespace ERP_SupplyChain.Controllers
{
    [PSessionCheck]
    public class MakeAppointmentController : Controller
    {

        AppointmentDAL appointment = new AppointmentDAL();
        //
        // GET: /MakeAppointment/
        public ActionResult AppointmentIndex()
        {
            return View();
        }

        // GET: /MakeAppointment/
        public ActionResult Appointments( )
        {
            AppointmentDAL AppDAL = new AppointmentDAL();
            int ID = int.Parse(Session["PatientID"].ToString());
            List<AppointmentDetails> details = AppDAL.getAppointmentDetails(ID);

            return View(details);
        }

        // GET: /MakeAppointment/
        public ActionResult BookAppointment(int id,string DoctorName,string Date)
        {
            ViewBag.DoctorID = id;
            ViewBag.DoctorName = DoctorName;
            ViewBag.Date = Date;
            Session["DoctorID"] = id;
            return View();
        }

        public JsonResult CheckTimeSlot(string TimeSlot)
        {
            using (ERP1DataContext dc = new ERP1DataContext())
            {
                return Json(!dc.Appointments.Any(x => x.TimeSlot == TimeSlot && x.DoctorID == int.Parse(Session["DoctorID"].ToString())), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult CheckSchedule(string Date)
        {
            DateTime date = Convert.ToDateTime(Date); ;
            using (ERP1DataContext dc = new ERP1DataContext())
            {
                var result = dc.Schedules.Where(x => x.Start.Date == date.Date).FirstOrDefault();

                if (result != null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);

                }
                return Json(false, JsonRequestBehavior.AllowGet);


            }
        }

        [HttpPost]
        public ActionResult BookAppointment(AppointmentModel model,int DocID, int PID)
        {
            if (ModelState.IsValid)
            {
                
                model.DoctorID = DocID;
                model.PatientID = PID;
                appointment.SaveAppointment(model);
                return View();
            }
            else
                return View();
        }


        [HttpPost]
        public ActionResult AvailableDoctor(FormCollection fc)
        {
            ERPDataContext dc = new ERPDataContext();
            DocScheduleQuery qdata = new DocScheduleQuery();
            DocScheduleStatus Doc = new DocScheduleStatus();
            List<DocScheduleStatus> status = new List<DocScheduleStatus>();
            if (ModelState.IsValid)
            {
                qdata.Date = Convert.ToDateTime(fc["Date"]);
                qdata.Department = Convert.ToString(fc["Department"]);
                var result = dc.Schedules.Where(x => x.Start.Date == qdata.Date.Date).FirstOrDefault();
                if (result != null)
                {
                    var data = from ds in dc.DoctorSchedules
                               join doc in dc.Doctors on ds.DoctorID equals doc.DoctorID
                               where ds.EventID == result.EventID
                               select new
                               {

                                   DoctorID = doc.DoctorID,
                                   Department = doc.Department,
                                   DoctorName = doc.FirstName + doc.LastName,
                               };

                    var doctor = from doc in data
                                 where (doc.Department == qdata.Department)
                                 select new
                                 {
                                     Date = result.Start,
                                     DoctorID = doc.DoctorID,
                                     Department = doc.Department,
                                     DoctorName = doc.DoctorName
                                 };
                    if (doctor != null)
                    {
                        foreach (var v in doctor)
                        {
                            Doc.DoctorID = v.DoctorID;
                            Doc.Date = qdata.Date.ToString("MM/dd/yyyy");
                            Doc.Department = v.Department;
                            Doc.DoctorName = v.DoctorName;
                            Doc.Status = result.Subject;
                        }
                        status.Add(Doc);
                        return View(status);
                    }
                    else
                    {
                        ViewBag.NoDoctor = "No Doctor is Available";
                        return Redirect("/MakeAppointment/AppointmentIndex");
                    }

                }
                ViewBag.NoSchedule = "No Schedule Availble";
                return Redirect("/MakeAppointment/AppointmentIndex");
            }
            return View();
              
        }
	}
} 