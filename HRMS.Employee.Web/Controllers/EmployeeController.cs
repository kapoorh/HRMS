using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Employee.Web.Models;

namespace HRMS.Employee.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private unitofwork unitofWork = null;
        public EmployeeController() : this(new unitofwork())
        {
        }

        public EmployeeController(unitofwork uow)
        {
            this.unitofWork = uow;
        }

        public ActionResult Index()
        {            
            List<EmployeesModel> allEmployees = unitofWork.employeeRepository.GetEmployees();
            return View(allEmployees);
        }

        public ActionResult Details(int id = 0)
        {            
            List<EmployeesModel> allEmployees = unitofWork.employeeRepository.GetEmployees();
            EmployeesModel employeemodeldet = allEmployees.SingleOrDefault(x => x.ID == id);
            if (employeemodeldet == null)
            {
                return HttpNotFound();
            }
            return View(employeemodeldet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create  

        [HttpPost]
        public void Create(EmployeesModel newEmployee)
        {
            try
            {
                // TODO: Add insert logic here  
                EmployeesModel studentmodel = new EmployeesModel();

                studentmodel.First_Name = newEmployee.First_Name.ToString();
                studentmodel.Last_Name = newEmployee.Last_Name.ToString();
                studentmodel.Email = newEmployee.Email.ToString();
                studentmodel.Dob = Convert.ToDateTime(newEmployee.Dob.ToString());
                studentmodel.Gender = newEmployee.Gender.ToString();
                studentmodel.Address = newEmployee .Address.ToString();
                studentmodel.City = newEmployee.City.ToString();
                studentmodel.State = newEmployee.State.ToString();
                studentmodel.Pin = newEmployee.Pin.ToString();

                
                unitofWork.employeeRepository.InsertEmployeesModel(studentmodel);
                
            }
            catch(Exception e)
            {
                string s = e.ToString();    
            }
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            List<EmployeesModel> allEmployees = unitofWork.employeeRepository.GetEmployees();
            EmployeesModel employeemodeldet = allEmployees.SingleOrDefault(x => x.ID == id);
            return View(employeemodeldet);
        }

        [HttpPost]
        public ActionResult Edit(int id, EmployeesModel editEmployee)
        {
            if (ModelState.IsValid)
            {
                
                List<EmployeesModel> allEmployees = unitofWork.employeeRepository.GetEmployees();
                EmployeesModel employeemodeledit = allEmployees.FirstOrDefault(x => x.ID == id);
                employeemodeledit.ID = id;

                employeemodeledit.First_Name = editEmployee.First_Name.ToString();
                employeemodeledit.Last_Name = editEmployee.Last_Name.ToString();
                employeemodeledit.Email = editEmployee.Email.ToString();
                employeemodeledit.Dob = Convert.ToDateTime(editEmployee.Dob.ToString());
                employeemodeledit.Gender = editEmployee.Gender.ToString();
                employeemodeledit.Address = editEmployee.Address.ToString();
                employeemodeledit.City = editEmployee.City.ToString();
                employeemodeledit.State = editEmployee.State.ToString();
                employeemodeledit.Pin = editEmployee.Pin.ToString();

                unitofWork.employeeRepository.EditEmployeesModel(employeemodeledit);
                
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            List<EmployeesModel> allEmployees = unitofWork.employeeRepository.GetEmployees();
            EmployeesModel employeemodeldet = allEmployees.SingleOrDefault(x => x.ID == id);
            return View(employeemodeldet);
        }

        [HttpPost]
        public void Delete(int id, FormCollection formcollection)
        {
            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository();
                unitofWork.employeeRepository.DeleteEmployeesModel(id);
            
            }

            catch (Exception)
            {
                
            }

        }
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
