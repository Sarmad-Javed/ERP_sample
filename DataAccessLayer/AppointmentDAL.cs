using ERPEntities;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public  class AppointmentDAL
    {
       public void SaveAppointment(AppointmentModel amodel)
       {
           ERP1DataContext dc = new ERP1DataContext();
           Appointment App = new Appointment();
           {
               App.DoctorID = amodel.DoctorID;
               App.PatientID = amodel.PatientID;
               App.Description = amodel.Description;
               App.Date = amodel.Date;
               App.TimeSlot = amodel.TimeSlot;
           }
           dc.Appointments.InsertOnSubmit(App);
           dc.SubmitChanges();
       }
    }
}
