using DataAccessLayer.DAL_Logic.Appointments;
using DataAccessLayer.DAL_Logic.FrontDesk;
using ERPEntities;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_SupplyChain.Controllers
{
    public class FrontDeskController : Controller
    {
        DoctorDAL Doc = new DoctorDAL();
        List<AppointmentDetails> details = new List<AppointmentDetails>();
        ERP1DataContext dc = new ERP1DataContext();
        //
        // GET: /FrontDesk/
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult AddSchedule()
        {
            return View();
        }

        //Get Assign Schedule
        public ActionResult AssignSchedule()
        {
            List<DepartmentVM> Departments = new List<DepartmentVM>();
            Departments.Add(new DepartmentVM() { Department = "Cardiology", Value = "Cardiology" });
            Departments.Add(new DepartmentVM() { Department = "Neurology", Value = "Neurology" });
            Departments.Add(new DepartmentVM() { Department = "Gynecology", Value = "Gynecology" });
            Departments.Add(new DepartmentVM() { Department = "Gastrology", Value = "Gastrology" });
            Departments.Add(new DepartmentVM() { Department = "Arthropathy", Value = "Arthropathy" });
            Departments.Add(new DepartmentVM() { Department = "Dermatology", Value = "Dermatology" });

            ViewBag.Department = new SelectList(Departments, "Value", "Department");

            List<Schedule> ScheduleList = dc.Schedules.ToList();
            ViewBag.ScheduleList = new SelectList(ScheduleList, "EventID", "Subject");
            return View();
        }

        // GET: /Schedule/GetDoctorList
        public JsonResult GetDoctorList(string department)
        {
            //db.Configration.ProxyCreation enabled = false;
            List<Doctor> DoctorList = dc.Doctors.Where(x => x.Department == department).ToList();

            return Json(DoctorList, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult SaveSchedule(int DoctorID, int EventID)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ERP1DataContext dc = new ERP1DataContext())
                {

                    DoctorSchedule ds = new DoctorSchedule();
                    ds.DoctorID = DoctorID;
                    ds.EventID = EventID;
                    dc.DoctorSchedules.InsertOnSubmit(ds);
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
        //Get Event
        public JsonResult GetEvents()
        {
            using (ERP1DataContext dc = new ERP1DataContext())
            {
                var events = dc.Schedules.ToList();

                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //Save Event
        [HttpPost]
        public JsonResult SaveEvent(Schedule s)
        {
            var status = false;
            using (ERP1DataContext dc = new ERP1DataContext())
            {
                if (s.EventID > 0)
                {
                    //Update the event
                    var v = dc.Schedules.Where(a => a.EventID == s.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = s.Subject;
                        v.Start = s.Start;
                        v.End = s.End;
                        v.Description = s.Description;
                        v.IsFullDay = s.IsFullDay;
                        v.Theme = s.Theme;
                    }
                }
                else
                {
                    dc.Schedules.InsertOnSubmit(s);
                }
                dc.SubmitChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        //Delete Event
        [HttpPost]
        public JsonResult deleteEvent(int eventID)
        {
            var status = false;
            using (ERP1DataContext dc = new ERP1DataContext())
            {
                var v = dc.Schedules.Where(a => a.EventID == eventID).FirstOrDefault();
                var data = dc.DoctorSchedules.Where(a => a.EventID == eventID).ToList();
                if (v != null || data != null)
                {
                    foreach (DoctorSchedule ds in data)
                    {
                        dc.DoctorSchedules.DeleteOnSubmit(ds);
                    }
                    dc.Schedules.DeleteOnSubmit(v);
                    dc.SubmitChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult ScheduleApp()
        {
            FrontDeskDAL Front = new FrontDeskDAL();
            List<AppointmentDetails> details = Front.getScheduledAppointmentDetails();
            return View(details);
        }

        public ActionResult ReferedApp()
        {
            FrontDeskDAL Front = new FrontDeskDAL();
            List<AppointmentDetails> details = Front.getReferedAppointmentDetails();
            return View(details);
        }

        public ActionResult GenerateBill(int id)
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
        public JsonResult ChangeAppStatus(int id)
        {
            bool status = false;
            if (id != 0)
            {
                var data = dc.Appointments.Where(a => a.AppointmentID == id).ToList();
                foreach (Appointment A in data)
                {
                    A.Status = "Finished";
                }
                dc.SubmitChanges();
                status = true;
                return new JsonResult { Data = new { status = status } };
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult SaveBill(BillVM B)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ERP1DataContext dc = new ERP1DataContext())
                {

                    string Day = DateTime.Now.Day.ToString();
                    string Month = DateTime.Now.Month.ToString();
                    string Year = DateTime.Now.Year.ToString();
                    Bill bill = new Bill { AppointmentID = B.AppointmentID, DoctorID = B.DoctorID, PatientID = B.PatientID, TotalAmount = decimal.Parse(B.TotalAmount), AddedDay = Day, AddedMonth = Month, AddedYear = Year };
                    foreach (var i in B.BillDetails)
                    {
                        //
                        // i.TotalAmount = 
                        bill.BillDetails.Add(i);
                    }
                    dc.Bills.InsertOnSubmit(bill);
                    dc.SubmitChanges();
                    status = true;
                    return new JsonResult { Data = new { status = status } };
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
	}
}