using BusinessLogicLayer;
using ERPEntities;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_SupplyChain.Controllers.Accounts
{
    
    public class PatientAccountsController : Controller
    {
        PatientAccountLogic PatientAccounts = new PatientAccountLogic();
        DashboardController DashBoard = new DashboardController();
        List<AuthenticatedPatient> User = new List<AuthenticatedPatient>();
        ERP1DataContext dc = new ERP1DataContext();
        //
        // GET: /PatientAccounts/
        public ActionResult PatientLogin()
        {
            return View();
        }


        public ActionResult PatientRegistration()
        {
            return View();
        }

        public JsonResult CheckUserName(string UserName)
        {
            return Json(!dc.Patients.Any(x => x.UserName == UserName), JsonRequestBehavior.AllowGet);
        }

        //Json Method to validate Email
        public JsonResult CheckEmail(string Email)
        {
            return Json(!dc.Patients.Any(x => x.PatientEmail == Email), JsonRequestBehavior.AllowGet);
        }

        //POST:/Accounts/Login
        [HttpPost]
        public ActionResult PatientLogin(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                User = PatientAccounts.Authenticate(login);
                string PatientUserName = User.Select(x => x.UserName).FirstOrDefault().ToString();
                string P_loginID = User.Select(x => x.P_LoginID).FirstOrDefault().ToString();
                string PatientImage = User.Select(x => x.PatientImage).FirstOrDefault().ToString();
                string PatientName = User.Select(x => x.PatientName).FirstOrDefault().ToString();
                Session["PatientUserName"] = PatientUserName;
                Session["PatientID"] = P_loginID;
                Session["PatientImage"] = PatientImage;
                Session["PatientName"] = PatientName;
                if (Session["PatientName"] == null)
                {
                    return Redirect("/ManagePatient/AddPatient");
                }
                else 
                    return Redirect("/Dashboard/Patient");
            }
            else
                return Redirect("/PatientAccounts/PatientLogin");;

        }

        [HttpPost]
        public ActionResult PatientRegistration(PatientRegistrationModel PReg)
        {
            if (ModelState.IsValid)
            {
                Patient p = new Patient();
                p.PatientEmail = PReg.Email;
                p.UserName = PReg.UserName;
                p.Password = PReg.Password;
                dc.Patients.InsertOnSubmit(p);
                dc.SubmitChanges();
                return Redirect("/PatientAccounts/PatientLogin");

            }
            else
                return View();

        }
        public ActionResult PatientLogout()
        {
            Session["PatientName"] = null;
            Session["PatietnID"] = null;
            Session["PatientImage"] = null;

            return Redirect("/PatientAccounts/PatientLogin");
        }
	}
}