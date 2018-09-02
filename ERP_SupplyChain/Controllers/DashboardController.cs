using BusinessLogicLayer;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_SupplyChain.Controllers
{
    public class DashboardController : Controller
    {
        AccountLogic Accounts = new AccountLogic();
        List<AuthenticatedUser> User = new List<AuthenticatedUser>();
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            if (Session["Userinfo"] != null)
            {
                User = Session["Userinfo"] as List<AuthenticatedUser>;
                return View(User);
            }
            else
            {
                return Redirect("/Accounts/Login");
            }
        }
        public ActionResult Admin()
        {   
            if(Session["Userinfo"] != null)
              {
                  User = Session["Userinfo"] as List<AuthenticatedUser>;
                  return View(User);
              }
            else
            {
                return Redirect("/Accounts/Login");
            }
        }
       
	}
}