using BusinessLogicLayer;
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
        //
        // GET: /PatientAccounts/
        public ActionResult PatientLogin()
        {
            return View();
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

        public ActionResult PatientLogout()
        {
            Session["PatientName"] = null;
            Session["PatietnID"] = null;
            Session["PatientImage"] = null;

            return Redirect("/PatientAccounts/PatientLogin");
        }
	}
}