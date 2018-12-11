using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class LowStockVM
    {
        public int StockID { get; set; }
        public String ItemName { get; set; }
        public int Quantity{ get; set; }  
    }
}
