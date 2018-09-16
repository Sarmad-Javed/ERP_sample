using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.DataContext;
using ERPEntities.Models;


namespace DataAccessLayer.DAL_Logic.PatientAccounts
{
    public class PatientAccountDAL
    {
        ERPDataContext db = new ERPDataContext();

        List<AuthenticatedPatient> UserList = new List<AuthenticatedPatient>();

        public List<AuthenticatedPatient> AuthenticatePatient(LoginModel login)
        {
            var result = db.Patients.FirstOrDefault(x => x.UserName.Equals(login.UserName) && x.Password.Equals(login.Password));

            if (result != null)
            {
                AuthenticatedPatient patient = new AuthenticatedPatient();
                var data = db.Patients.Where(x => x.PatientEmail == result.PatientEmail);
                foreach (var v in data)
                {
                    patient.P_LoginID = v.PatientID;
                    patient.UserName = v.UserName;
                    patient.Password = v.Password;
                    patient.PatientName = v.PatientName;
                    patient.Email = v.PatientEmail;
                    patient.isAvailable = v.isAvailable;
                    patient.PatientImage = v.PatientImage;
                    UserList.Add(patient);
                }
            }
            return UserList;
        }
    }
}
