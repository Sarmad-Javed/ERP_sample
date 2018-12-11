using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class PrescriptionVM
    {
            public int PrescriptionID { get; set; }
            public int AppointmentID { get; set; }
            public int DoctorID { get; set; }
            public int PatientID { get; set; }
            public List<Medication> MedDetails { get; set; }
        
    }
    public class MedDetails
    {
        public int PrescriptionID { get; set; }
        public string MedType { get; set; }
        public string MedName { get; set; }
        public string Strength { get; set; }
        public string Duration { get; set; }
        public string Dose { get; set; }
        public string Dignosis { get; set; }

    }
}
