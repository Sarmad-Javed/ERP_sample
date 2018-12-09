using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class AppointmentVM
    {
        public int DoctorID { get; set; }
        public int Department{ get; set; }
        public string Date { get; set; }
        public string TimeSlot { get; set;}
        public string Description { get; set; }
        
    }

    public class AvailableDoctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
    }
}
