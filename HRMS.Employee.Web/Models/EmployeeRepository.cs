using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace HRMS.Employee.Web.Models
{
    public class EmployeeRepository :IEmployeeRepository
    {
        public List<EmployeesModel> allEmployees;
        public XDocument EmployeesData;

        public EmployeeRepository()
        {
            try
            {
                allEmployees = new List<EmployeesModel>();
                EmployeesData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/employeedata.xml"));
                var Employees = from t in EmployeesData.Descendants("employee")
                               select new EmployeesModel(
                                   (int)t.Element("ID"),
                                   t.Element("first_name").Value,
                               t.Element("last_name").Value,
                               t.Element("email").Value,
                               (DateTime)t.Element("dob"),
                               t.Element("gender").Value,                               
                               t.Element("address").Value,
                               t.Element("city").Value,
                               t.Element("state").Value,
                               t.Element("pin").Value);

                allEmployees.AddRange(Employees.ToList<EmployeesModel>());
            }
            catch (Exception exp)
            {
                throw;
                //throw new NotImplementedException();
            }
        }

        public List<EmployeesModel> GetEmployees()
        {
            return allEmployees;
        }

        //public EmployeesModel GetStudentByID(int id)
        //{
        //    return allStudents.Find(item => item.ID == id);
        //}

        public void InsertEmployeesModel(EmployeesModel employee)
        {
            employee.ID = (int)(from S in EmployeesData.Descendants("employee") orderby (int)S.Element("ID") descending select (int)S.Element("ID")).FirstOrDefault() + 1;

            EmployeesData.Root.Add(new XElement("employee", new XElement("ID", employee.ID),
                new XElement("first_name", employee.First_Name),
                new XElement("last_name", employee.Last_Name),
                new XElement("email", employee.Email),
                new XElement("dob", employee.Dob.Date.ToShortDateString()),
                new XElement("gender", employee.Gender),
                new XElement("address", employee.Address),
                new XElement("city", employee.City),
                new XElement("state", employee.State),
                new XElement("pin", employee.Pin)));

            EmployeesData.Save(HttpContext.Current.Server.MapPath("~/App_Data/employeedata.xml"));
        }

        public void EditEmployeesModel(EmployeesModel employee)
        {
            try
            {
                XElement node = EmployeesData.Root.Elements("employee").Where(i => (int)i.Element("ID") == employee.ID).FirstOrDefault();

                node.SetElementValue("first_name", employee.First_Name);
                node.SetElementValue("last_name", employee.Last_Name);
                node.SetElementValue("email", employee.Email);
                node.SetElementValue("dob", employee.Dob.ToShortDateString());
                node.SetElementValue("gender", employee.Gender);
                
                node.SetElementValue("address", employee.Address);
                node.SetElementValue("city", employee.City);
                node.SetElementValue("state", employee.State);
                node.SetElementValue("pin", employee.Pin);
                EmployeesData.Save(HttpContext.Current.Server.MapPath("~/App_Data/employeedata.xml"));
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }


        public void DeleteEmployeesModel(int id)
        {
            try
            {
                EmployeesData.Root.Elements("employee").Where(i => (int)i.Element("ID") == id).Remove();

                EmployeesData.Save(HttpContext.Current.Server.MapPath("~/App_Data/employeedata.xml"));

            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
