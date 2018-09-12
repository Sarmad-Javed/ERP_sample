using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class ScheduleModel
    {
        public int EventID { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime Start{ get; set; }

        public DateTime End { get; set; }

        public string Theme { get; set; }

        public bool IsFullDay { get; set; }
    }
}
