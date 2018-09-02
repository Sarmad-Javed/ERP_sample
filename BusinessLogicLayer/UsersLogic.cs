using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.Models;
using DataAccessLayer.DAL_Logic.Admin;
using System.Data;
using System.Collections;
using System.Reflection;

namespace BusinessLogicLayer
{
    public class UsersLogic
    {
        //Initializaton
        UserDAL UserDAL = new UserDAL();
        List<UserModel> UserList = new List<UserModel>();


        //add record
        public void addUsers(AddUserModel User)
        {
            UserDAL.addUser(User);
        }

        //getItemList
        public List<UserModel> getItemsList()
        {
            UserList = UserDAL.getUsersList();
            return UserList;
        }

        public List<UserModel> viewUserListByID(int id)
        {
            UserList = UserDAL.viewUserListByID(id);
            return UserList;
        }

        //getItembyID
        public UserModel viewUserByID(int id)
        {
            UserModel User = new UserModel();
            User = UserDAL.viewUserByID(id);
            return User;
        }

        //UpdateItem
        public void updateUser(int id,UserModel user)
        {
            UserDAL.updateUser(id,user);
        }

        //deleteItem
        public void deleteUser(int id)
        {
            UserDAL.deleteUser(id);
        }

    }
}
