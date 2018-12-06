using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERPEntities.Models
{
    public class ItemsModel
    {
        public int ItemID { get; set; }

        [Required(ErrorMessage = "VendorID required")]
        public int VendorID { get; set; }

        [Required(ErrorMessage = "VendorID required")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "VendorID required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "VendorID required")]
        [DataType(DataType.Date)]
        public DateTime MfgDate { get; set; }

        [Required(ErrorMessage = "VendorID required")]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }

        [Required(ErrorMessage = "VendorID required")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "VendorID required")]
        public double PurchasePrice { get; set; }

        [Required(ErrorMessage = "VendorID required")]
        [Display(Name = "Unit")]
        public string Unit_of_Measure { get; set; }

        [Required(ErrorMessage = "VendorID required")]
        public int LeadTime { get; set; }
    }

    public class StockModel
    {
        public int ItemID { get; set; }

        public int VendorID { get; set; }

        public int CategoryID { get; set; }

        public string ItemName { get; set; }

        public string MfgDate { get; set; }
   
        public string ExpDate { get; set; }

        public double UnitPrice { get; set; }

        public double PurchasePrice { get; set; }

        public string Unit_of_Measure { get; set; }

        public int LeadTime { get; set; }
    }
}
