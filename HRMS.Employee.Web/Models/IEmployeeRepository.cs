using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Employee.Web.Models
{
   public interface IEmployeeRepository
    {
        List<EmployeesModel> GetEmployees();      
        void InsertEmployeesModel(EmployeesModel Employee);
        void EditEmployeesModel(EmployeesModel Employee);
        void DeleteEmployeesModel(int id);
    }
}