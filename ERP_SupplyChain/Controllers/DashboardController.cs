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

    }
}