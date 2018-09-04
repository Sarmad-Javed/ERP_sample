using BusinessLogicLayer;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_SupplyChain.Controllers
{   [SessionCheck]
    public class DashboardController : Controller
    {
        AccountLogic Accounts = new AccountLogic();

        List<AuthenticatedUser> User = new List<AuthenticatedUser>();

        //
        // GET: /Dashboard/Supply Chain
        public ActionResult SupplyChain()
        {
           return View();
        }

        // GET: /Dashboard/Admin
        public ActionResult Admin()
        {
            return View();
        }

        // GET: /Dashboard/Pharmacy
        public ActionResult Pharmacy()
        {
            return View();
        }

        // GET: /Dashboard/HR_Index
        public ActionResult HRIndex()
        {
            return View();
        }

        // GET: /Dashboard/FD_Index
        public ActionResult FrontDesk()
        {
            return View();
        }

        // GET: /Dashboard/Doctor_Index
        public ActionResult DoctorPanel()
        {
            return View();
        }

    }
}