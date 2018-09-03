using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAL_Logic.Employee.ManageAttendance;
using ERPEntities.Models;

namespace BusinessLogicLayer
{
    public class AttendanceLogic
    {
        //Initializaton
        AttendanceDAL AttendanceDAL = new AttendanceDAL();
        List<AttendanceModel> AttendanceList = new List<AttendanceModel>();


        //add record
        public void addAttendance(AddAttendanceModel attendance)
        {
            AttendanceDAL.addAttendance(attendance);
        }

        //get Attendance List
        public List<AttendanceModel> getAttendanceList()
        {
            AttendanceList = AttendanceDAL.getAttendanceList();
            return AttendanceList;
        }

        public List<AttendanceModel> viewAttendanceListByID(int id)
        {
            AttendanceList = AttendanceDAL.viewAttendanceListByID(id);
            return AttendanceList;
        }

        //getItembyID
        public AttendanceModel viewAttendanceByID(int id)
        {
            AttendanceModel attendance = new AttendanceModel();
            attendance = AttendanceDAL.viewAttendanceByID(id);
            return attendance;
        }

        //UpdateItem
        public void updateAttendance(int id, AttendanceModel attendance)
        {
            AttendanceDAL.updateAttendance(id, attendance);
        }

        //deleteItem
        public void deleteAttendance(int id)
        {
            AttendanceDAL.deleteAttendance(id);
        }

    }
}