using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
using System.IO;

namespace ERPEntities.Models
{
    [MetadataType(typeof(UserMataData))]
    public class UserModel
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int RoleID { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public string UserImage { get; set; }
    }

    public class UserMataData
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "FirstName required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName required")]
        public string LastName { get; set; }

        [Remote("CheckUserName", "ManageUser", ErrorMessage = "UserName already exist")]
        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
        
        [Remote("CheckEmail", "ManageUser", ErrorMessage = "Email already exist")]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "RoleID required")]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "UserImage required")]
        public HttpPostedFileBase Image { get; set; }

        public string UserImage { get; set; }
    }

    [MetadataType(typeof(LoginMetaData))]
    public class LoginModel
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }

    }
    public class LoginMetaData
    {
        [Remote("CheckUserName", "Accounts", ErrorMessage = "Username not found")]
        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }

         [Remote("CheckPassword", "Accounts", ErrorMessage = "Wrong Password")]
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

    }

    public class AuthenticatedUser
    {
        public int AuthenticatedUserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public string UserImage { get; set; }

    }

    public class EditProfile
    {
        public int AuthenticatedUserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string UserImage { get; set; }


    }
}
