
using DataAccessLayer.DAL_Logic.PatientAccounts;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PatientAccountLogic
    {
       
            List<AuthenticatedPatient> UserList = new List<AuthenticatedPatient>();
            PatientAccountDAL AuthenticateUser = new PatientAccountDAL();

            public List<AuthenticatedPatient> Authenticate(LoginModel login)
            {
                UserList = AuthenticateUser.AuthenticatePatient(login);
                return UserList;

            }


        
    }
}
