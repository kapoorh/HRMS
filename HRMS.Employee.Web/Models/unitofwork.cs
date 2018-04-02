using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Employee.Web.Models
{
    public class unitofwork
    {
        public unitofwork()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            //DummyEmployeeRepository dummyEmployeeRepository = new DummyEmployeeRepository();
        }

        public unitofwork(IEmployeeRepository employeeRepo)
        {
            employeeRepository = employeeRepo;

        }

        public IEmployeeRepository employeeRepository
        {
            get;
            private set;
        }
    }
}