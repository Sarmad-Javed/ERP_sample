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
}
