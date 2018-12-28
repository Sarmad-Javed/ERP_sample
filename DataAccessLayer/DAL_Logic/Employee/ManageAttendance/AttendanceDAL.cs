using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPEntities.Models;

namespace DataAccessLayer.DAL_Logic.Employee.ManageAttendance
{
    public class AttendanceDAL
    {
        List<AttendanceModel> AttendanceList = new List<AttendanceModel>();
        AttendanceModel attendance = new AttendanceModel();
        SqlConnection Sqlcon = new SqlConnection("Data Source=Ijlal07-PC;Initial Catalog=ERP;Integrated Security=True");
        public void addAttendance(AddAttendanceModel attendance)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Add_Attendance", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@EmployeeID", attendance.EmployeeID);
                Sqlcmd.Parameters.AddWithValue("@Month", attendance.Month);
                Sqlcmd.Parameters.AddWithValue("@WorkingDays", attendance.WorkingDays);
                Sqlcmd.Parameters.AddWithValue("@Absents", attendance.Absents);
                
                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public List<AttendanceModel> getAttendanceList()
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_Show_Attendance", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                AttendanceModel attendance = new AttendanceModel();
                attendance.AttendanceID = Convert.ToInt32(dr["AttendanceID"]);
                attendance.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                attendance.Month = Convert.ToString(dr["Month"]);
                attendance.WorkingDays = Convert.ToInt32(dr["WorkingDays"]);
                attendance.Absents = Convert.ToInt32(dr["Absents"]);
                
                AttendanceList.Add(attendance);
            }
            Sqlcon.Close();
            return AttendanceList;
        }

        public List<AttendanceModel> viewAttendanceListByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_AttendancebyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@AttendanceID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {

                attendance.AttendanceID = Convert.ToInt32(dr["AttendanceID"]);
                attendance.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                attendance.Month = Convert.ToString(dr["Month"]);
                attendance.WorkingDays = Convert.ToInt32(dr["WorkingDays"]);
                attendance.Absents = Convert.ToInt32(dr["Absents"]);
                
                AttendanceList.Add(attendance);

            }
            Sqlcon.Close();
            return AttendanceList;
        }

        public AttendanceModel viewAttendanceByID(int id)
        {
            SqlCommand Sqlcmd = new SqlCommand("SP_View_AttendancebyID", Sqlcon);
            Sqlcmd.CommandType = CommandType.StoredProcedure;
            Sqlcmd.Parameters.AddWithValue("@AttendanceID", id);
            Sqlcon.Open();
            SqlDataReader dr = Sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                attendance.AttendanceID = Convert.ToInt32(dr["AttendanceID"]);
                attendance.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                attendance.Month = Convert.ToString(dr["Month"]);
                attendance.WorkingDays = Convert.ToInt32(dr["WorkingDays"]);
                attendance.Absents = Convert.ToInt32(dr["Absents"]);
                
            }
            Sqlcon.Close();
            return attendance;
        }

        public void updateAttendance(int id, AttendanceModel attendance)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                Sqlcon.Open();
                SqlCommand Sqlcmd = new SqlCommand("SP_Update_Attendance", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@AttendanceID", id);
                Sqlcmd.Parameters.AddWithValue("@EmployeeID", attendance.EmployeeID);
                Sqlcmd.Parameters.AddWithValue("@Month", attendance.Month);
                Sqlcmd.Parameters.AddWithValue("@WorkingDays", attendance.WorkingDays);
                Sqlcmd.Parameters.AddWithValue("@Absents", attendance.Absents);
                
                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }

        public void deleteAttendance(int id)
        {
            if (Sqlcon.State == ConnectionState.Closed)
            {
                SqlCommand Sqlcmd = new SqlCommand("SP_Delete_Attendance", Sqlcon);
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@AttendanceID", id);
                Sqlcon.Open();
                Sqlcmd.ExecuteNonQuery();
                Sqlcon.Close();

            }
        }


    }
}
