using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class AppointmentDetails
    {
        public int AppointmentID { get; set; }

        public int DoctorID { get; set; }

        public string DoctorName { get; set; }

        public string DoctorEmail { get; set; }

        public string DoctorImage { get; set; }

        public string Designation { get; set; }

        public int PatientID { get; set; }

        public string PatientName { get; set; }

        public string PatientEmail { get; set; }

        public string PatientImage{ get; set; }

        public string PatientContact { get; set; }

        public string Description { get; set; }

        public string TimeSlot { get; set; }

        public string Date { get; set; }
    }
}
