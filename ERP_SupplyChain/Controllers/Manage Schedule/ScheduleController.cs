using ERPEntities;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_SupplyChain.Controllers
{
    public class ScheduleController : Controller
    {
        ERP1DataContext dc = new ERP1DataContext();
        //
        // GET: /Schedule/
        public ActionResult ScheduleIndex()
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
                    foreach(DoctorSchedule ds in data)
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


	}
}