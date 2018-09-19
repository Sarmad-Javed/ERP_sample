using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ERPEntities.Models
{
    [MetadataType(typeof(PatientRegMetaData))]
    public class PatientRegistrationModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
   

    public class PatientRegMetaData
    {
        [Remote("CheckUserName", "PatientAccounts", ErrorMessage = "Username already exist")]
        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }

        [Remote("CheckEmail", "PatientAccounts", ErrorMessage = "Email already exist")]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }

    public class AuthenticatedPatient
    {
        public int P_LoginID { get; set; }

        public string UserName { get; set; }

        public string PatientName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public bool isAvailable { get; set; }
        public string PatientImage { get; set; }

    }
}
