using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERPEntities.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "FirstName required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email required")]
        public String Email { get; set; }

        [Required(ErrorMessage = "RoleID required")]
        public int RoleID { get; set; }
    }

    public class AddUserModel
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public String Email { get; set; }

        [Required(ErrorMessage = "RoleID required")]
        public int RoleID { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "UserName required")]
        public string UserName { get; set; }
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

        public String Email { get; set; }

        public int RoleID { get; set; }

        public string RoleName{get;set;}

    }
}
