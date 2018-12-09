using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.DataContext;
using ERPEntities.Models;

namespace DataAccessLayer.DAL_Logic.Accounts
{
    public class AuthenticateUserDAL
    {
        ERPDataContext db = new ERPDataContext();

        List<AuthenticatedUser> UserList = new List<AuthenticatedUser>();

        public List<AuthenticatedUser> Authenticate(LoginModel login)
        {
            var result = db.Users.FirstOrDefault(x => x.UserName.Equals(login.UserName) && x.Password.Equals(login.Password));
            
            if ( result != null)
            {
                AuthenticatedUser User = new AuthenticatedUser();
                var data = from u in db.Users
                           join r in db.Roles on u.RoleID equals r.RoleID
                           where u.UserID == result.UserID
                           select new
                           {
                               UserID = u.UserID,
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               UserName = u.UserName,
                               UserImage = u.UserImage,
                               Email = u.Email,
                               RoleName = r.RoleName,
                               DoctorID = u.DoctorID,
                               
                               
                           };
                foreach (var v in data)
                {
                    User.AuthenticatedUserID = v.UserID;
                    User.FirstName = v.FirstName;
                    User.LastName = v.LastName;
                    User.UserName = v.UserName;
                    User.UserImage = v.UserImage;
                    User.Email = v.Email;
                    User.DoctorID = (int)v.DoctorID;
                    User.RoleName = v.RoleName;
                    UserList.Add(User);
                } 
            }
             return UserList;
        }
    }
}
