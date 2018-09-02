using DataAccessLayer.DAL_Logic.Accounts;
using ERPEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer
{
    public class AccountLogic
    {
         List<AuthenticatedUser> UserList = new List<AuthenticatedUser>();
         AuthenticateUserDAL AuthenticateUser = new AuthenticateUserDAL();

         public List<AuthenticatedUser> Authenticate(LoginModel login)
         {
            UserList =  AuthenticateUser.Authenticate(login);
            return UserList;
                 
         }

         
    }
}
