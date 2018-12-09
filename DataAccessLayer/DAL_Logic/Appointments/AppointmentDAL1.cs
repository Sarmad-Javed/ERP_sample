using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.Models;
using ERPEntities;

namespace DataAccessLayer.DAL_Logic.Appointments
{
    public class AppointmentDAL1
    {
        public bool CheckSchedule(bool status,string Date)
        {
            DateTime date = Convert.ToDateTime(Date); ;
            using (ERP1DataContext dc = new ERP1DataContext())
            {
                var result = dc.Schedules.Where(x => x.Start.Date == date.Date).FirstOrDefault();

                if (result != null)
                {
                    status = true;
                    return status;
                }
                else
                {
                    status = false;
                    return status;
                }
            }
        }

        //timeSlot
        public bool TimeSlot( bool status,int DocID, string Date, string slot)
        {
            DateTime date = Convert.ToDateTime(Date); ;
            using (ERP1DataContext dc = new ERP1DataContext())
            {
                var result = dc.Appointments.Where(x => x.Date == date.Date && x.DoctorID == DocID && x.TimeSlot == slot).FirstOrDefault();

                if (result != null)
                {
                    status = true;
                    return status;

                }
                else
                {
                    status = false;
                    return status;
                }
            }
        }

        //book
        public bool BookDoctor(AppointmentModel App, bool status)
        {
             using (ERP1DataContext dc = new ERP1DataContext())
             {
                    Appointment A = new Appointment();
                        A.DoctorID = App.DoctorID;
                        A.PatientID = App.PatientID;
                        A.Date = App.Date;
                        A.Description = App.Description;
                        A.TimeSlot = App.TimeSlot;
                        A.Status = "Scheduled";
                       dc.Appointments.InsertOnSubmit(A);
                       dc.SubmitChanges();
                       status = true;

                       return status;
             }
                    
                    
        }


        public bool DeleteAppointment(int Id,bool status)
        {
            using (ERP1DataContext dc = new ERP1DataContext())
            {
                var AppData = dc.Appointments.Where(a => a.AppointmentID == Id).ToList();

                if (AppData != null)
                {
                    foreach (Appointment ds in AppData)
                    {
                        dc.Appointments.DeleteOnSubmit(ds);
                    }
                    dc.SubmitChanges();
                    return status = true;
                }
                return status = false;
            }
        }
     }      
}
