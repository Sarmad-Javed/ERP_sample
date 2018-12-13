using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class BillVM
    {
        public int BillID { get; set; }
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string TotalAmount { get; set; }
        public List<BillDetail> BillDetails { get; set; }
    }
}
