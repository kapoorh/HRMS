using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Employee.Web.Models;

namespace HRMS.Employee.Web.Controllers
{
    public class HomeController : Controller
    {        

        private unitofwork unitofWork = null;

        public HomeController() : this(new unitofwork())
        {
                
        }

        public HomeController(unitofwork uow)
        {
            this.unitofWork = uow;
        }

        public ActionResult Index()
        {
            EmployeeRepository EmployeeRepository = new EmployeeRepository();
            List <EmployeesModel> allstudents = EmployeeRepository.GetEmployees();
            return View(allstudents);
        }

        public ActionResult Details(int id=0)
        {
            EmployeeRepository EmployeeRepository = new EmployeeRepository();
            List<EmployeesModel> allstudents = EmployeeRepository.GetEmployees();
            EmployeesModel studentmodeldet = allstudents.SingleOrDefault(x=>x.ID==id);
            if (studentmodeldet == null)
            {
                return HttpNotFound();
            }
            return View(studentmodeldet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create  

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here  
                EmployeesModel studentmodel = new EmployeesModel();
               
                studentmodel.First_Name = collection["First_Name"].ToString();
                studentmodel.Last_Name = collection["Last_Name"].ToString();
                studentmodel.Email = collection["Email"].ToString();
                studentmodel.Dob = Convert.ToDateTime(collection["Dob"].ToString());
                studentmodel.Gender = collection["Gender"].ToString();
                studentmodel.Address = collection["Address"].ToString();
                studentmodel.City = collection["City"].ToString();
                studentmodel.State = collection["State"].ToString();
                studentmodel.Pin = collection["Pin"].ToString();

                EmployeeRepository EmployeeRepository = new EmployeeRepository();
                EmployeeRepository.InsertEmployeesModel(studentmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeRepository EmployeeRepository = new EmployeeRepository();
            List<EmployeesModel> allstudents = EmployeeRepository.GetEmployees();
            EmployeesModel studentmodeldet = allstudents.SingleOrDefault(x => x.ID == id);
            return View(studentmodeldet);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection frmcollection)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository EmployeeRepository = new EmployeeRepository();
                List<EmployeesModel> allstudents = EmployeeRepository.GetEmployees();
                EmployeesModel studentmodeledit = allstudents.FirstOrDefault(x => x.ID == id);
                studentmodeledit.ID = id;

                studentmodeledit.First_Name = frmcollection["First_Name"].ToString();
                studentmodeledit.Last_Name = frmcollection["Last_Name"].ToString();
                studentmodeledit.Email = frmcollection["Email"].ToString();
                studentmodeledit.Dob = Convert.ToDateTime(frmcollection["Dob"].ToString());
                studentmodeledit.Gender = frmcollection["Gender"].ToString();
                studentmodeledit.Address = frmcollection["Address"].ToString();
                studentmodeledit.City = frmcollection["City"].ToString();
                studentmodeledit.State = frmcollection["State"].ToString();
                studentmodeledit.Pin = frmcollection["Pin"].ToString();

                EmployeeRepository.EditEmployeesModel(studentmodeledit);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            EmployeeRepository EmployeeRepository = new EmployeeRepository();
            List<EmployeesModel> allstudents = EmployeeRepository.GetEmployees();
            EmployeesModel studentmodeldet = allstudents.SingleOrDefault(x => x.ID == id);
            return View(studentmodeldet);
        }

        [HttpPost]
        public ActionResult Delete(int id,FormCollection formcollection)
        {
            try
            {
                EmployeeRepository EmployeeRepository = new EmployeeRepository();
                EmployeeRepository.DeleteEmployeesModel(id);
                return RedirectToAction("Index");
            }

            catch(Exception exp)
            {
                throw;
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