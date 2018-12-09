using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities.Models;
using ERPEntities.DataContext;
using DataAccessLayer.DAL_Logic.Appointments;

namespace ERP_SupplyChain.Controllers.ManageAppointment
{
    public class AppointmentController : Controller
    {
        AppointmentDAL1 appointment = new AppointmentDAL1();
        //
        // GET: /Appointment/
        public ActionResult AppointmentIndex()
        {
            List<DepartmentVM> Departments = new List<DepartmentVM>();
            Departments.Add(new DepartmentVM() { Department = "Cardiology", Value = "Cardiology" });
            Departments.Add(new DepartmentVM() { Department = "Neurology", Value = "Neurology" });
            Departments.Add(new DepartmentVM() { Department = "Gynaecology", Value = "Gynaecology" });
            Departments.Add(new DepartmentVM() { Department = "Gastrology", Value = "Gastrology" });
            Departments.Add(new DepartmentVM() { Department = "Genral Medicine", Value = "Genral Medicine" });
            Departments.Add(new DepartmentVM() { Department = "Arthopathy", Value = "Arthopathy" });
            Departments.Add(new DepartmentVM() { Department = "Dermatology", Value = "Dermatology" });

             List<TimeSlotVM> TimeSlots = new List<TimeSlotVM>();
             TimeSlots.Add(new TimeSlotVM(){ Text = "8:00-8:15", Value = "8:00-8:15" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "8:15-8:30", Value = "8:15-8:30" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "8:15-8:30", Value = "8:15-8:30" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "8:30-8:45", Value = "8:30-8:45" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "8:45-9:00", Value = "8:45-9:00" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "9:00-9:15", Value = "9:00-9:15" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "9:15-9:30", Value = "9:15-9:30" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "9:30-9:45", Value = "9:30-9:45" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "9:45-10:00", Value = "9:45-10:00" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "10:00-10:15", Value = "10:00-10:15" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "10:15-10:30", Value = "10:15-10:30" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "10:30-10:45", Value = "10:30-10:45" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "10:45-11:00", Value = "10:45-11:00" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "11:15-11:30", Value ="11:15-11:30" });
             TimeSlots.Add(new TimeSlotVM(){ Text = "11:30-11:45", Value = "11:30-11:45" });
             TimeSlots.Add(new TimeSlotVM() { Text = "11:45-12:00", Value = "11:45-12:00" });
                                                        

              ViewBag.Department = new SelectList(Departments, "Value", "Department");
              ViewBag.TimeSlot = new SelectList(TimeSlots, "Value", "Text");
            return View();
        }
        
        //checkSchedule
        public JsonResult CheckSchedule(string Date)
        {
            bool status = false;
            status = appointment.CheckSchedule(status,Date);
            if (status == true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        //timeSlot
        public JsonResult TimeSlot(int DocID,string Date,string slot)
        {
            bool status = false;
            status = appointment.TimeSlot(status,DocID,Date,slot);
                if (status == true)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);

                }
                return Json(false, JsonRequestBehavior.AllowGet);
        }

        //AvailableDoctors
        public JsonResult AvailableDoctors(string Date,string Department)
        {
            ERPDataContext dc = new ERPDataContext();
            List<AvailableDoctor> Doctors = new List<AvailableDoctor>();
            DocScheduleQuery qdata = new DocScheduleQuery();
            
            if (Date != null & Department != null)
            {
                qdata.Date = Convert.ToDateTime(Date);
                qdata.Department = Department;
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
                                     DoctorID = doc.DoctorID,
                                     DoctorName = doc.DoctorName
                                 };
                    if (doctor != null)
                    {
                        foreach (var v in doctor)
                        {
                            AvailableDoctor a = new AvailableDoctor();
                            a.DoctorID = v.DoctorID;
                            a.DoctorName = v.DoctorName;
                            Doctors.Add(a);
                        }
                        return Json(Doctors, JsonRequestBehavior.AllowGet);
                    }
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //Delete Appointment
        public JsonResult DeleteAppointment(int AppID)
        {
            bool status = false;
            status =  appointment.DeleteAppointment(AppID, status);
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        //Delete Appointment
        public JsonResult BookAppointment(AppointmentModel App)
        {
            bool status = false;
            status = appointment.BookDoctor(App, status);
            return new JsonResult { Data = new { status = status } };
        }
	}
}