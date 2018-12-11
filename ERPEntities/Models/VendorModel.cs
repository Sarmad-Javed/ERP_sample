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
    [MetadataType(typeof(VendorMetaData))]
    public class VendorModel
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string VendorContact { get; set; }
        public int ZIPCode { get; set; }
    }
    public class VendorMetaData
    {
        public int VendorID { get; set; }

        [Remote("CheckVendor", "ManageVendor",ErrorMessage = "vendorName already exist")]
        [Required(ErrorMessage = "Item Name required")]
        [StringLength(20)]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }

        [Required(ErrorMessage = "VendorAddress required")]
        public string VendorAddress { get; set; }

        [Required(ErrorMessage = "Contact required")]
        public int VendorContact { get; set; }

        [Required(ErrorMessage = "ZIPCode required")]
        public int ZIPCode { get; set; }
    }

    public class AddVendorModel
    {
        public int VendorID { get; set; }

        public string VendorName { get; set; }

        public string VendorAddress { get; set; }

        public string VendorContact { get; set; }

        public int ZIPCode { get; set; }
    }
}