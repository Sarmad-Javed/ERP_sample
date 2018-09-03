using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class VendorModel
    {
        public int VendorID { get; set; }

        [Required(ErrorMessage = "FirstName required")]
        public string VendorName { get; set; }

        [Required(ErrorMessage = "LastName required")]
        public string VendorAddress { get; set; }

        [Required(ErrorMessage = "UserName required")]
        public string VendorContact { get; set; }

        [Required(ErrorMessage = "Password required")]
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