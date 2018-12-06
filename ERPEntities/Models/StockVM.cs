using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class StockVM
    {
        public List<StockModel> ItemDetails { get; set; }
    }

    public class QuantityVM
    {
        public int OrderID { get; set; }
        public List<ItemQuantityVM> ItemQuantity { get; set; }
    }
}
