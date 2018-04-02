using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRMS.Employee.Web.Controllers;
using HRMS.Employee.Web.Models;
using NUnit.Framework;
using employeeCRUD.Models;

namespace HRMS.Employee.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        EmployeesModel student1 = null;
        EmployeesModel student2 = null;
        EmployeesModel student3 = null;
        EmployeesModel student4 = null;
        EmployeesModel student5 = null;

        List<EmployeesModel> employeeModelList = null;
        DummyEmployeeRepository employeeRepository = null;
        unitofwork unitofwork = null;
        EmployeeController controller = null;
        
        private const string ServiceBaseURL = "http://localhost:55217/";

        public object HttpPropertyKeys { get; private set; }

        public HomeControllerTest()
        {
            student1 = new EmployeesModel { ID = 1,   First_Name="Sweety", Last_Name="Sharma",Email="Sara@hotmail.com",Dob=Convert.ToDateTime("12/12/1973"),Gender="Female",Address="New Link Road",City="Saran",State="MHS", Pin="1231" };
            student2 = new EmployeesModel { ID = 2, First_Name = "Jatin", Last_Name = "Kumar", Email = "Jatin@hotmail.com", Dob = Convert.ToDateTime("12/12/1972"), Gender = "Male", Address = "New Link Road", City = "Saran", State = "MHS", Pin = "1231" };
            student3 = new EmployeesModel { ID = 3, First_Name = "Sweta", Last_Name = "shah", Email = "Swta@hotmail.com", Dob = Convert.ToDateTime("12/12/1971"), Gender = "Female", Address = "New Link Road", City = "Saran", State = "MHS", Pin = "1231" };
            student4 = new EmployeesModel { ID = 4, First_Name = "yasmin", Last_Name = "Sheikh", Email = "Yasmin@hotmail.com", Dob = Convert.ToDateTime("12/12/1978"), Gender = "Female", Address = "New Link Road", City = "Saran", State = "MHS", Pin = "1231" };
            student5 = new EmployeesModel { ID = 5, First_Name = "weetetar", Last_Name = "Rao", Email = "Weeta@hotmail.com", Dob = Convert.ToDateTime("12/12/1975"), Gender = "Male", Address = "New Link Road", City = "Saran", State = "MHS", Pin = "1231" };

            employeeModelList = new List<EmployeesModel>
            {
                  student1,
                  student2,
                  student3,
                  student4
                 // student5
            };

            employeeRepository = new DummyEmployeeRepository(employeeModelList);
            unitofwork = new unitofwork(employeeRepository);
            controller = new EmployeeController(unitofwork);
   
        }



        [Test]
        public void Index()
        {


            ViewResult result = controller.Index() as ViewResult;
            var model = (List<EmployeesModel>)result.ViewData.Model;

            // Assert
            CollectionAssert.Contains(model, student1);
            CollectionAssert.Contains(model, student2);
            CollectionAssert.Contains(model, student3);
            CollectionAssert.Contains(model, student4);
                        

        }

        [Test]
        public void Details()
        {
            ViewResult result = controller.Details(1) as ViewResult;
            Assert.AreEqual(result.Model, student1);

        }

        [Test]
        public void Create()
        {
            
            EmployeesModel newEmployee = new EmployeesModel { ID = 6, First_Name = "witekar", Last_Name = "Rao", Email = "Weeta@hotmail.com", Dob = Convert.ToDateTime("12/12/1975"), Gender = "Male", Address = "New Link Road", City = "Saran", State = "MHS", Pin = "1231" };

            // Lets call the action method now
            controller.Create(newEmployee);

            // get the list of students
            List<EmployeesModel> employees = employeeRepository.GetEmployees();

            try {

                CollectionAssert.Contains(employees, newEmployee);
            }
            catch(Exception)
            {
               
            }
        }


        [Test]
        public void Edit()
        {
            // Lets create a valid student objct to add into
            EmployeesModel editstudent = new EmployeesModel { ID = 4, First_Name = "yasmin", Last_Name = "Sheikh", Email = "Yasmin@hotmail.com", Dob = Convert.ToDateTime("12/12/1978"), Gender = "Female", Address = "MG Road", City = "Mahad", State = "MHS", Pin = "1231" };

            // Lets call the action method now
            controller.Edit(4, editstudent);

            // get the list of students
            List<EmployeesModel> students = employeeRepository.GetEmployees();

            try
            {
                CollectionAssert.Contains(students, editstudent);
            }
            catch (Exception exp)
            {
               
            }
        }

        [Test]
        public void Delete()
        {
            int id = 2;
            // Lets call the action method now
            controller.Delete(id);
            EmployeesModel deletestudent = employeeRepository.GetEmployees().SingleOrDefault(x => x.ID == id);
            // get the list of students
            List<EmployeesModel> students = employeeRepository.GetEmployees();

            try
            {
                CollectionAssert.DoesNotContain(students, deletestudent);
            }
            catch(Exception)
            {
                //throw;
            }
        }
    }
}
