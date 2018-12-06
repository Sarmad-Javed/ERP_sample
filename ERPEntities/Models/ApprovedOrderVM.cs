using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class ApprovedOrderVM
    {
        public int OrderId { get; set; }
        public String OrderDate { get; set; }
        public string TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string Payment { get; set; }
    }
}
