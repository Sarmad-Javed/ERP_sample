using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.Models;
using ERPEntities.DataContext;

namespace DataAccessLayer.DAL_Logic.Pharmecy
{
    public class PharmecyDAL
    {
        ERPDataContext dc = new ERPDataContext();
        List<AppointmentDetails> AppList = new List<AppointmentDetails>();
        List<MedDetails> MedList = new List<MedDetails>();
        public List<AppointmentDetails> Appointments()
        {
            var AppID = dc.Appointments.Where(a => a.Status == "Prescribed").ToList();
            foreach(var val in AppID)
            {
                var result = from app in dc.Appointments
                         join doc in dc.Doctors on app.DoctorID equals doc.DoctorID
                         join p in dc.Patients on app.PatientID equals p.PatientID
                         where app.AppointmentID == val.AppointmentID
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

                    foreach (var v in result)
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
                    
            }
            return AppList;
        }

        public List<MedDetails> getMedDetails(int ID)
        {
            ERPDataContext dc = new ERPDataContext();
            var result = from pres in dc.Prescriptions
                         join m in dc.Medications on pres.PrescriptionID equals m.PrescriptionID
                         where pres.AppointmentID == ID
                         select new
                         {
                             MedType = m.MedType,
                             MedName = m.MedName,
                             Strength = m.Strength,
                             Duration = m.Duration,
                             Dose = m.Dose,
                             Dignosis = m.Dignosis,
                         };


            foreach (var v in result)
            {

                MedDetails details = new MedDetails();
                details.MedType = v.MedType;
                details.MedName = v.MedName;
                details.Strength = v.Strength;
                details.Duration = v.Duration;
                details.Dose = v.Dose;
                details.Dignosis = v.Dignosis;
                MedList.Add(details);

            }

            return MedList;
        }
    }
}
