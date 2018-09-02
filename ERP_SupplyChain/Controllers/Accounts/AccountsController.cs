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
                Session["Userinfo"] = User;
               
                if (role == "SupplyChain")
                {
                    return Redirect("/DashBoard/Index");
                }
                if (role == "Pharmacy")
                {
                    return Redirect("/DashBoard/Pharmacy");
                }
                if (role == "Doctor")
                {
                    return Redirect("/DashBoard/Doctor");
                }
                if (role == "Admin")
                {   
                    return Redirect("/DashBoard/Admin");
                }
                if (role == "FrontDesk")
                {
                    return Redirect("/DashBoard/FrontDesk");
                }
                else
                    return View();
            }
            else
                return View();
     
        }

         public ActionResult UserDetail(List<AuthenticatedUser> User)
        {
            
             return View();
        }
	}
}