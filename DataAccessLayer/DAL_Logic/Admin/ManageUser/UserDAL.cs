using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using System.Configuration;
using ERPEntities;
using ERPEntities.Models;
using System.Data.SqlClient;

namespace DataAccessLayer.DAL_Logic.Admin
{
    public class UserDAL
    {
        List<UserModel> UserList= new List<UserModel>();
        UserModel user = new UserModel();
        SqlConnection Sqlcon = new SqlConnection("Data Source=pc-sarmad;Initial Catalog=ERP;Integrated Security=True");
        public void addUser(AddUserModel user)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Add_User", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                Sqlcmd.Parameters.AddWithValue("@LastName", user.LastName);
                Sqlcmd.Parameters.AddWithValue("@UserName", user.UserName);
                Sqlcmd.Parameters.AddWithValue("@Password", user.Password);
                Sqlcmd.Parameters.AddWithValue("@Email", user.Email);
                Sqlcmd.Parameters.AddWithValue("@RoleID", user.RoleID);

                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public List<UserModel> getUsersList()
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_Show_Users", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                UserModel user= new UserModel();
                user.UserID = Convert.ToInt32(dr["UserID"]);
                user.FirstName = Convert.ToString(dr["FirstName"]);
                user.LastName = Convert.ToString(dr["LastName"]);
                user.UserName = Convert.ToString(dr["UserName"]);
                user.Password = Convert.ToString(dr["Password"]);
                user.Email = Convert.ToString(dr["Email"]);
                user.RoleID = Convert.ToInt32(dr["RoleID"]);
                
                UserList.Add(user);
            }
            Sqlcon.Close();
            return UserList;
        }

        public List<UserModel> viewUserListByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_UserbyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@UserID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {

                user.UserID = Convert.ToInt32(dr["UserID"]);
                user.FirstName = Convert.ToString(dr["FirstName"]);
                user.LastName = Convert.ToString(dr["LastName"]);
                user.UserName = Convert.ToString(dr["UserName"]);
                user.Password = Convert.ToString(dr["Password"]);
                user.Email = Convert.ToString(dr["Email"]);
                user.RoleID = Convert.ToInt32(dr["RoleID"]);
                UserList.Add(user);

            }
            Sqlcon.Close();
            return UserList;
        }

        public UserModel viewUserByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_UserbyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@UserID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                
                user.UserID = Convert.ToInt32(dr["UserID"]);
                user.FirstName = Convert.ToString(dr["FirstName"]);
                user.LastName = Convert.ToString(dr["LastName"]);
                user.UserName = Convert.ToString(dr["UserName"]);
                user.Password = Convert.ToString(dr["Password"]);
                user.Email = Convert.ToString(dr["Email"]);
                user.RoleID = Convert.ToInt32(dr["RoleID"]);

                
            }
            Sqlcon.Close();
            return user;
        }

        public void updateUser(int id,UserModel user)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Update_User", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@UserID", id);
                Sqlcmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                Sqlcmd.Parameters.AddWithValue("@LastName", user.LastName);
                Sqlcmd.Parameters.AddWithValue("@UserName", user.UserName);
                Sqlcmd.Parameters.AddWithValue("@Password", user.Password);
                Sqlcmd.Parameters.AddWithValue("@Email", user.Email);
                Sqlcmd.Parameters.AddWithValue("@RoleID", user.RoleID);

                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public void deleteUser(int id)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Delete_User", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@UserID",id);
                Sqlcon.Open();
                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

       
    }
}
