using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class PatientloginModel
    {

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
