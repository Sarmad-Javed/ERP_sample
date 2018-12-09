using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class ScheduleVM
    {
        public string Department { get; set; }
        public int DoctorID { get; set; }
        public int ScheduleID { get; set; }
    }

    public class DepartmentVM
    {
        public string Department { get; set; }
        public string Value { get; set; }

    }
    public class TimeSlotVM
    {
        public string Text { get; set; }
        public string Value { get; set; }

    }
}
