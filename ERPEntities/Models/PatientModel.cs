using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class PatientModel
    {
        public int PatientID { get; set; }

        [Required(ErrorMessage = "PatientName required")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "PatientAddress required")]
        public string PatientAddress { get; set; }

        [Required(ErrorMessage = "PatientContact required")]
        public string PatientContact { get; set; }

        [Required(ErrorMessage = "PatientEmail required")]
        public string PatientEmail { get; set; }

        [Required(ErrorMessage = "ZIPCode required")]
        public int ZIPCode { get; set; }
    }

    public class AddPatientModel
    {
        public int PatientID { get; set; }
        
        public string PatientName { get; set; }
        
        public string PatientAddress { get; set; }
        
        public string PatientContact { get; set; }
        
        public string PatientEmail { get; set; }
        
        public int ZIPCode { get; set; }
    }
}