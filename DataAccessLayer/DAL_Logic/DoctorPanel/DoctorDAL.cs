using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities;
using ERPEntities.Models;


namespace DataAccessLayer.DAL_Logic.Appointments
{
    public class DoctorDAL
    {
        List<AppointmentDetails> AppList = new List<AppointmentDetails>();

        public List<AppointmentDetails> getAppointmentDetails(int ID)
        {
            ERP1DataContext dc = new ERP1DataContext();
            var result = from app in dc.Appointments
                         join doc in dc.Doctors on app.DoctorID equals doc.DoctorID
                         join p in dc.Patients on app.PatientID equals p.PatientID
                         where app.DoctorID == ID
                         select new
                         {
                             AppointmentID = app.AppointmentID,
                             DoctorID = doc.DoctorID,
                             Department = doc.Designation,
                             DoctorName = doc.FirstName + doc.LastName,
                             DoctorImage = doc.Image,
                             DoctorEmail = doc.DoctorEmail,
                             PatientID = p.PatientID,
                             PatientName = p.PatientName,
                             PatientEmail = p.PatientEmail,
                             PatientContact = p.PatientContact,
                             PatientImage = p.PatientImage,
                             Date = app.Date,
                             TimeSlot = app.TimeSlot,
                             Status = app.Status

                         };

            var data = from r in result where (r.Status == "Scheduled") select r;
            if (data != null)
            {
                foreach (var v in data)
                {

                    AppointmentDetails details = new AppointmentDetails();
                    details.AppointmentID = v.AppointmentID;
                    details.DoctorID = v.DoctorID;
                    details.Designation = v.Department;
                    details.DoctorName = v.DoctorName;
                    details.DoctorImage = v.DoctorImage;
                    details.DoctorEmail = v.DoctorEmail;
                    details.PatientID = v.PatientID;
                    details.PatientName = v.PatientName;
                    details.PatientEmail = v.PatientEmail;
                    details.PatientContact = v.PatientContact;
                    details.PatientImage = v.PatientImage;
                    details.Date = v.Date.ToString();
                    details.TimeSlot = v.TimeSlot;
                    AppList.Add(details);

                }

                return AppList;
            }

            return AppList;

        }
    }
}
