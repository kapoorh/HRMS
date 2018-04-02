using HRMS.Employee.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace employeeCRUD.Models
{
    public class DummyEmployeeRepository : IEmployeeRepository
    {
        List<EmployeesModel> employeemodellist = null;

        public DummyEmployeeRepository(List<EmployeesModel> employee)
        {
            this.employeemodellist = employee;
        }

        public List<EmployeesModel> GetEmployees()
        {
            return employeemodellist;
        }

        public void InsertEmployeesModel(EmployeesModel employee)
        {
            employeemodellist.Add(employee);
        }

        public void EditEmployeesModel(EmployeesModel employeeedit)
        {
            int id = employeeedit.ID;
            EmployeesModel employeetotupdate = employeemodellist.SingleOrDefault(x => x.ID == id);
            DeleteEmployeesModel(id);
            employeemodellist.Add(employeeedit);
        }

        public void DeleteEmployeesModel(int id)
        {
            EmployeesModel employeetoDel = employeemodellist.SingleOrDefault(x => x.ID == id);
            employeemodellist.Remove(employeetoDel);
        }       
    }
}