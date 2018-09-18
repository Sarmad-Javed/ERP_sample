using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERPEntities.Models
{
    [MetadataType(typeof(AppointmentMetaData))]
    public class AppointmentModel
    {
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID{ get; set; }

        public string Description { get; set; }

        public string TimeSlot { get; set; }

        public DateTime Date { get; set; }
    }

    public class AppointmentMetaData
    {
        public int AppointmentID { get; set; }

        public int DoctorID { get; set; }

        public int PatientID { get; set; }

        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }

        [Remote("CheckTimeSlot", "MakeAppointment", ErrorMessage = "TimeSlot already booked")]
        [Required(ErrorMessage = "TimeSlot required")]
        public string TimeSlot { get; set; }

        [Required(ErrorMessage = "Date required")]
        public DateTime Date { get; set; }
    }

    [MetadataType(typeof(QueryMetaData))]
    public class DocScheduleQuery
    {
        public DateTime Date { get; set; }

        public string Department { get; set; }
    }
    
    public class QueryMetaData
    {
        [Remote("CheckSchedule", "MakeAppointment", ErrorMessage = "No Schedule available")]
        [Required(ErrorMessage = "Date required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Department required")]
        public string Department { get; set; }
    }

    public class DocScheduleStatus
    {
        public string DoctorName { get; set; }
        public string Status { get; set; }

        public int DoctorID { get; set; }

        public string Department { get; set; }

        public string Date { get; set; }
    }
}
