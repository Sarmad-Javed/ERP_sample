using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class OrderDetailVM
    {
        public int ItemId { get; set; }
        public string ItemName {get;set;}
        public string VendorName {get;set;}
        public string Category {get;set;}
        public int Quanitity {get;set;}
        public decimal Price {get;set;}
        public decimal TotalAmount {get;set;}
        public string OrderDate { get; set; }
        public string GrandTotal { get; set; }
        public string  OrderStatus{ get; set; }
       
    }

    public class DeliveredDetailsVM
    {

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string VendorName { get; set; }
        public string Category { get; set; }
        public int Quanitity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderDate { get; set; }
        public string GrandTotal { get; set; }
        public string OrderStatus { get; set; }
    }

    public class ApprovedDetailsVM
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string VendorName { get; set; }
        public string Category { get; set; }
        public int Quanitity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderDate { get; set; }
        public string GrandTotal { get; set; }
        public string OrderStatus { get; set; }
    }

}
