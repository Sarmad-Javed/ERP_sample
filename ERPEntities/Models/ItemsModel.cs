using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERPEntities.Models
{
    [MetadataType(typeof(ItemsMetaData))]
    public class ItemsModel
    {
        public int ItemID { get; set; }
        public int VendorID { get; set; }
        public int CategoryID { get; set; }
        public string ItemName { get; set; }
        public DateTime MfgDate { get; set; }
        public DateTime ExpDate { get; set; }
        public double UnitPrice { get; set; }
        public double PurchasePrice { get; set; }
        public string Unit_of_Measure { get; set; }
        public int LeadTime { get; set; }
    }
    public class ItemsMetaData
    {
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Vendor required")]
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }

        [Required(ErrorMessage = "Category required")]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Remote("CheckItem", "Inventory",AdditionalFields="VendorID", ErrorMessage = "Item already exist")]
        [Required(ErrorMessage = "Item Name required")]
        [StringLength(20)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Mfg Date required")]
        [DataType(DataType.Date)]
        public DateTime MfgDate { get; set; }

        [Required(ErrorMessage = "Exp required")]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }

        [Required(ErrorMessage = "Unit Price required")]
        [Display(Name = "Sale Price")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Purchase required")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Unit required")]
        [Display(Name = "Unit")]
        public string Unit_of_Measure { get; set; }

        [Required(ErrorMessage = "LeadTime required")]
        [Display(Name = "Lead Time")]
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
