using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class InvoiceVM
    {
        public int  InvoiceID { get; set; }
        public int  AppointmentID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceStatus { get; set; }
        public string TotalAmount { get; set; }
        public string Payment { get; set; }
        public int StockQuantity { get; set; }
        public int StockID { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
        public List<InvoiceQtyVM> QuantityDetails { get; set; }
    }
    public class InvoiceQtyVM
    {
        public int StockID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal cast { get; set; }
        
    }
    public class GenrateInvoiceVM
    {
        public int CategoryID { get; set; }
        public int StockID { get; set; }
        public int Quantity{ get; set; }
        public DateTime InvoiceDate { get; set; }
        
    }

    public class GetInvoiceVM
    {
        public int InvoiceID { get; set; }
        public string Total { get; set; }
        public DateTime InvoiceDate { get; set; }

    }


}
