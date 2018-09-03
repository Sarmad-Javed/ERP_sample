using BusinessLogicLayer;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_SupplyChain.Controllers
{
<<<<<<< HEAD
    public class DashboardController : Controller
    {
        AccountLogic Accounts = new AccountLogic();
        List<AuthenticatedUser> User = new List<AuthenticatedUser>();
        //
        // GET: /Dashboard/Supply Chain
        public ActionResult SC_Index()
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

        // GET: /Dashboard/Admin
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

        // GET: /Dashboard/Pharmacy
        public ActionResult Pharm_Index()
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

        // GET: /Dashboard/HR_Index
        public ActionResult HR_Index()
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

        // GET: /Dashboard/FD_Index
        public ActionResult FD_Index()
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

        // GET: /Dashboard/Doctor_Index
        public ActionResult Doctor_Index()
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
       
=======
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
	   
>>>>>>> db6666cc8e62d46f7539fe4b2e985ff139f19fb2
	}
}