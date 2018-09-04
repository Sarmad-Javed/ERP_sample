using BusinessLogicLayer;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_SupplyChain.Controllers.Accounts
{
    public class AccountsController : Controller
    {
        AccountLogic Accounts = new AccountLogic();
        DashboardController DashBoard = new DashboardController();
        List<AuthenticatedUser> User = new List<AuthenticatedUser>();
        //
        // GET: /Accouts/
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View(User);
        }

        //POST:/Accounts/Login
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                User = Accounts.Authenticate(login);
                string role = User.Select(x => x.RoleName).FirstOrDefault().ToString();
                string UserName = User.Select(x => x.UserName).FirstOrDefault().ToString();
                string UserID = User.Select(x => x.AuthenticatedUserID).FirstOrDefault().ToString();
                string UserImage = User.Select(x => x.UserImage).FirstOrDefault().ToString();
                Session["UserName"] = UserName;
                Session["UserID"] = UserID;
                Session["UserImage"] = UserImage;
               
                if (role == "SupplyChain")
                {
                    return Redirect("/DashBoard/SupplyChain");
                }
                if (role == "Pharmacy")
                {
                    return Redirect("/DashBoard/Pharmacy");
                }
                if (role == "HRManager")
                {
                    return Redirect("/DashBoard/HRIndex");
                }
                if (role == "Doctor")
                {
                    return Redirect("/DashBoard/DoctorPanel");
                }
                if (role == "Admin")
                {   
                    return Redirect("/DashBoard/Admin");
                }
                if (role == "FDManager")
                {
                    return Redirect("/DashBoard/FrontDesk");
                }
                else
                    return View();
            }
            else
                return View();
     
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            Session["UserID"] = null;
            Session["UserImage"] = null;
               
            return Redirect("/Accounts/Login");
        }
	}
}