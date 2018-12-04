using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPEntities.DataContext;
namespace ERPEntities.Models
{
    public class OrderVM
    {
        public int id { get; set; }      
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string TotalAmount { get; set; }
        public string Payment { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
