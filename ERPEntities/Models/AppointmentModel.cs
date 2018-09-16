using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace ERPEntities.Models
{
    public class AppointmentModel
    {

    }
    public class DocScheduleQuery
    {
      
        public string Date { get; set; }

        public string Department { get; set; }
    }

    public class DocScheduleStatus
    {
        public string DoctorName { get; set; }
        public string type { get; set; }
    }
}
