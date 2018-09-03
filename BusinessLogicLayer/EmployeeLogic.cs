using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAL_Logic.Employee.ManageEmployee;
using ERPEntities.Models;

namespace BusinessLogicLayer
{
    public class EmployeeLogic
    {
        //Initializaton
        EmployeeDAL EmployeeDAL = new EmployeeDAL();
        List<EmployeeModel> EmployeeList = new List<EmployeeModel>();


        //add record
        public void addEmployee(AddEmployeeModel employee)
        {
            EmployeeDAL.addEmployee(employee);
        }

        //get Employee List
        public List<EmployeeModel> getEmployeeList()
        {
            EmployeeList = EmployeeDAL.getEmployeesList();
            return EmployeeList;
        }

        public List<EmployeeModel> viewEmployeeListByID(int id)
        {
            EmployeeList = EmployeeDAL.viewEmployeeListByID(id);
            return EmployeeList;
        }

        //getItembyID
        public EmployeeModel viewEmployeeByID(int id)
        {
            EmployeeModel employee = new EmployeeModel();
            employee = EmployeeDAL.viewEmployeeByID(id);
            return employee;
        }

        //UpdateItem
        public void updateEmployee(int id, EmployeeModel employee)
        {
            EmployeeDAL.updateEmployee(id, employee);
        }

        //deleteItem
        public void deleteEmployee(int id)
        {
            EmployeeDAL.deleteEmployee(id);
        }

    }
}