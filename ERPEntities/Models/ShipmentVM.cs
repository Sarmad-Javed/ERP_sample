using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class ShipmentVM
    {
        public int OrderID { get; set; }
        public string OrderDate  { get; set; }
        public string OrderStatus { get; set; }
    }
}
