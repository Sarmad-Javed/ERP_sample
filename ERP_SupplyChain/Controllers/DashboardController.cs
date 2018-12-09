using BusinessLogicLayer;
using ERPEntities.Models;
using System;
using DataAccessLayer;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities;

namespace ERP_SupplyChain.Controllers
{   
    public class DashboardController : Controller
    {
        AccountLogic Accounts = new AccountLogic();
        SchdeuleDAL ScheduleDAL = new SchdeuleDAL();
        List<AuthenticatedUser> User = new List<AuthenticatedUser>();

        //
        // GET: /Dashboard/Supply Chain
        public ActionResult SupplyChain()
        {
           return View();
        }
        public ActionResult Calender()
        {
            return View();
        }

        // GET: /Dashboard/Admin
        public ActionResult Admin()
        {
            return View();
        }

        // GET: /Dashboard/Pharmacy
        public ActionResult Pharmacy()
        {
            return View();
        }

        // GET: /Dashboard/HR_Index
        public ActionResult HRIndex()
        {
            return View();
        }

        // GET: /Dashboard/FD_Index
        public ActionResult FrontDesk()
        {
            return View();
        }

        // GET: /Dashboard/Doctor_Index
        public ActionResult DoctorPanel()
        {
            return View();
        }

        //GET : /Dashboard/Patient
        public ActionResult Patient()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (ERP1DataContext dc = new ERP1DataContext())
            {
                var events = dc.Schedules.ToList();

                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

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

    }
}