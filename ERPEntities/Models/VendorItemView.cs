using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class VendorItemView
    {

        public int VendorID { get; set; }
        public int CategoryID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public DateTime Orderdate { get; set; }
            
    }

}
