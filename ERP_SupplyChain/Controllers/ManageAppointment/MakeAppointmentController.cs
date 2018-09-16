using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using ERPEntities.Models;
using System.Data;
using ERPEntities.DataContext;
using System.Globalization;


namespace ERP_SupplyChain.Controllers
{
    [PSessionCheck]
    public class MakeAppointmentController : Controller
    {
        //
        // GET: /MakeAppointment/
        public ActionResult AppointmentIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AvailableDoctor(FormCollection fc)
        {
            ERPDataContext dc = new ERPDataContext();
            DocScheduleQuery qdata = new DocScheduleQuery();
            DocScheduleStatus Doc = new DocScheduleStatus();
            List<DocScheduleStatus> status = new List<DocScheduleStatus>();
           
               DateTime Date = Convert.ToDateTime(fc["Date"]);
               qdata.Department = Convert.ToString(fc["Department"]);
                var result = dc.Schedules.Where(x => x.Start.Date == Date.Date).FirstOrDefault();
                if (result != null)
                 {
                    var data = from ds in dc.DoctorSchedules
                               join doc in dc.Doctors on ds.DoctorID equals doc.DoctorID
                               where ds.EventID == result.EventID
                               select new
                               {
                                   DoctorName = doc.FirstName + doc.LastName,
                               };
                    if (data != null)
                    {
                        foreach (var v in data)
                        {
                            Doc.DoctorName = v.DoctorName;
                            Doc.type = result.Subject;
                        }
              
                    }
                        
                    status.Add(Doc);
                    return View(status);
                }
                return View(status);
        }
	}
} 