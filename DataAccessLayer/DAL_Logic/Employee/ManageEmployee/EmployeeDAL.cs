using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.Models;

namespace DataAccessLayer.DAL_Logic.Employee.ManageEmployee
{
    public class EmployeeDAL
    {
        List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
        EmployeeModel employee = new EmployeeModel();
        SqlConnection Sqlcon = new SqlConnection("Data Source=Ijlal07-PC;Initial Catalog=ERP;Integrated Security=True");
        public void addEmployee(AddEmployeeModel employee)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Add_Employee", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                Sqlcmd.Parameters.AddWithValue("@EmpAddress", employee.EmpAddress);
                Sqlcmd.Parameters.AddWithValue("@EmpContact", employee.EmpContact);
                Sqlcmd.Parameters.AddWithValue("@EmpEmail", employee.EmpEmail);
                Sqlcmd.Parameters.AddWithValue("@EmpCNIC", employee.EmpCNIC);
                Sqlcmd.Parameters.AddWithValue("@EmpDOB", employee.EmpDOB);
                Sqlcmd.Parameters.AddWithValue("@EmpDepartment", employee.EmpDepartment);
                Sqlcmd.Parameters.AddWithValue("@EmpDesignation", employee.EmpDesignation);
                Sqlcmd.Parameters.AddWithValue("@EmpRating", employee.EmpRating);

                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public List<EmployeeModel> getEmployeesList()
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_Show_Employee", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                EmployeeModel employee = new EmployeeModel();
                employee.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                employee.EmpName = Convert.ToString(dr["EmpName"]);
                employee.EmpAddress = Convert.ToString(dr["EmpAddress"]);
                employee.EmpContact = Convert.ToString(dr["EmpContact"]);
                employee.EmpEmail = Convert.ToString(dr["EmpEmail"]);
                employee.EmpCNIC = Convert.ToString(dr["EmpCNIC"]);
                employee.EmpDOB = Convert.ToDateTime(dr["EmpDOB"]);
                employee.EmpDepartment = Convert.ToString(dr["EmpDepartment"]);
                employee.EmpDesignation = Convert.ToString(dr["EmpDesignation"]);
                employee.EmpRating = Convert.ToString(dr["EmpRating"]);
                
                EmployeeList.Add(employee);
            }
            Sqlcon.Close();
            return EmployeeList;
        }

        public List<EmployeeModel> viewEmployeeListByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_EmployeebyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@EmployeeID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                employee.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                employee.EmpName = Convert.ToString(dr["EmpName"]);
                employee.EmpAddress = Convert.ToString(dr["EmpAddress"]);
                employee.EmpContact = Convert.ToString(dr["EmpContact"]);
                employee.EmpEmail = Convert.ToString(dr["EmpEmail"]);
                employee.EmpCNIC = Convert.ToString(dr["EmpCNIC"]);
                employee.EmpDOB = Convert.ToDateTime(dr["EmpDOB"]);
                employee.EmpDepartment = Convert.ToString(dr["EmpDepartment"]);
                employee.EmpDesignation = Convert.ToString(dr["EmpDesignation"]);
                employee.EmpRating = Convert.ToString(dr["EmpRating"]);
                EmployeeList.Add(employee);

            }
            Sqlcon.Close();
            return EmployeeList;
        }

        public EmployeeModel viewEmployeeByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_EmployeebyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@EmployeeID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                employee.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                employee.EmpName = Convert.ToString(dr["EmpName"]);
                employee.EmpAddress = Convert.ToString(dr["EmpAddress"]);
                employee.EmpContact = Convert.ToString(dr["EmpContact"]);
                employee.EmpEmail = Convert.ToString(dr["EmpEmail"]);
                employee.EmpCNIC = Convert.ToString(dr["EmpCNIC"]);
                employee.EmpDOB = Convert.ToDateTime(dr["EmpDOB"]);
                employee.EmpDepartment = Convert.ToString(dr["EmpDepartment"]);
                employee.EmpDesignation = Convert.ToString(dr["EmpDesignation"]);
                employee.EmpRating = Convert.ToString(dr["EmpRating"]);

            }
            Sqlcon.Close();
            return employee;
        }

        public void updateEmployee(int id, EmployeeModel employee)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Update_Employee", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@EmployeeID", id);
                Sqlcmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                Sqlcmd.Parameters.AddWithValue("@EmpAddress", employee.EmpAddress);
                Sqlcmd.Parameters.AddWithValue("@EmpContact", employee.EmpContact);
                Sqlcmd.Parameters.AddWithValue("@EmpEmail", employee.EmpEmail);
                Sqlcmd.Parameters.AddWithValue("@EmpCNIC", employee.EmpCNIC);
                Sqlcmd.Parameters.AddWithValue("@EmpDOB", employee.EmpDOB);
                Sqlcmd.Parameters.AddWithValue("@EmpDepartment", employee.EmpDepartment);
                Sqlcmd.Parameters.AddWithValue("@EmpDesignation", employee.EmpDesignation);
                Sqlcmd.Parameters.AddWithValue("@EmpRating", employee.EmpRating);

                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public void deleteEmployee(int id)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                SqlCommand Sqlcmd = new SqlCommand("SP_Delete_Employee", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@EmployeeID", id);
                Sqlcon.Open();
                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }


    }
}
