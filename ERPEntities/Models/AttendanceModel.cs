using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class AttendanceModel
    {
            public int AttendanceID { get; set; }

            public int EmployeeID { get; set; }

            [Required(ErrorMessage = "Month required")]
            public string Month { get; set; }

            [Required(ErrorMessage = "WorkingDays required")]
            public int WorkingDays { get; set; }

            [Required(ErrorMessage = "Absents required")]
            public int Absents { get; set; }
        }

        public class AddAttendanceModel
        {
            public int AttendanceID { get; set; }

            public int EmployeeID { get; set; }

            public string Month { get; set; }

            public int WorkingDays { get; set; }

            public int Absents { get; set; }
        }
    }