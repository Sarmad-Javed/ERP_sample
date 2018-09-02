using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using ERPEntities.Models;
using System.Data;


namespace ERP_SupplyChain.Controllers
{
    public class ManageUserController : Controller
    {
        //
        UsersLogic UserLogic = new UsersLogic();
        UserModel UserModel = new UserModel();
        List<UserModel> UserList = new List<UserModel>();
        // GET: /ManageUser/
        public ActionResult AddUser()
        {
            return View();
        }

        // GET: /ManageUser/ViewUser
        public ActionResult ViewUser()
        {
           UserList =  UserLogic.getItemsList();
            return View(UserList);
        }

        // GET: /ManageUser/updateUser
        public ActionResult Update(int id)
        {
            UserModel User = new UserModel();
            User = UserLogic.viewUserByID(id);
            return View(User);
        }

        // GET: /ManageUser/Details
        public ActionResult Details(int id)
        {
            
            UserList = UserLogic.viewUserListByID(id);
            return View(UserList);
        }

        // GET: /ManageUser/Delete
        public ActionResult Delete(int id)
        {
            UserLogic.deleteUser(id);
            return Redirect("ViewItems");
        }
        [HttpPost]
        public ActionResult AddUser(AddUserModel user)
        {
            if (ModelState.IsValid)
            { //clalling BLL function
                UserLogic.addUsers(user);
            }

            return View();
           
        }
        [HttpPost]
        public ActionResult Update(int id,UserModel user)
        {
            if (ModelState.IsValid)
            { //clalling BLL function
                UserLogic.updateUser(id,user);
            }

            return Redirect("Details?id=" + id);

        }
	}
}