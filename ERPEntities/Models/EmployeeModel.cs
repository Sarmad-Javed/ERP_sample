using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "EmployeeName required")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "EmpAddress required")]
        public string EmpAddress { get; set; }

        [Required(ErrorMessage = "EmployeeContact required")]
        public string EmpContact { get; set; }

        [Required(ErrorMessage = "EmployeeEmail required")]
        public string EmpEmail { get; set; }

        [Required(ErrorMessage = "EmployeeCNIC required")]
        public string EmpCNIC { get; set; }

        [Required(ErrorMessage = "EmployeeDOB required")]
        [DataType(DataType.Date)]
        public DateTime EmpDOB { get; set; }
        [Required(ErrorMessage = "EmployeeDepartment required")]
        public string EmpDepartment { get; set; }

        [Required(ErrorMessage = "EmployeeDesignation required")]
        public string EmpDesignation { get; set; }

        [Required(ErrorMessage = "EmployeeRating required")]
        public string EmpRating { get; set; }

    }

    public class AddEmployeeModel
    {
        public int EmployeeID { get; set; }

        public string EmpName { get; set; }

        public string EmpAddress { get; set; }

        public string EmpContact { get; set; }

        public string EmpEmail { get; set; }

        public string EmpCNIC { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmpDOB { get; set; }
        public string EmpDepartment { get; set; }

        public string EmpDesignation { get; set; }

        public string EmpRating { get; set; }

    }
}