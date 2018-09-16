using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace ERP_SupplyChain.Controllers
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase Session = filterContext.HttpContext.Session;
            if (Session["UserName"] == null && Session["UserID"] == null && Session["UserImage"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                                       { "Controller", "Accounts" },
                                       { "Action", "Login" }
                                       });
            }
        }
    }
    public class PSessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase Session = filterContext.HttpContext.Session;
            if (Session["PatientName"] == null && Session["P_loginID"] == null && Session["PatientImage"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary {
                                       { "Controller", "PatientAccounts" },
                                       { "Action", "PatientLogin" }
                                       });
            }
        }
    }
} 
  