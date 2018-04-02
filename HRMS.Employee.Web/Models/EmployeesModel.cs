using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace HRMS.Employee.Web.Models
{
    public class EmployeesModel
    {
        public EmployeesModel()
        {
            this.ID = 0;
            this.First_Name = null;
            this.Last_Name = null;
            this.Email = null;
            this.Dob = DateTime.Now;
            this.Gender = null;

            this.Address = null;
            this.City = null;
            this.State = null;
            this.Pin = null;
        }
        public int ID { get; set; }


        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name ="First Name")]
        public string First_Name { get; set; }
       [Required(ErrorMessage = "Last name is required")]
       [Display(Name ="Last Name")]
        public string Last_Name { get; set; }
       [Required(ErrorMessage = "Email name is required")]
        
        public string Email { get; set; }
        
       [Required(ErrorMessage = "Date of birth is required")]
        //[DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        [Display(Name ="Date Of Birth")]
        public DateTime Dob { get; set; }
       [Required(ErrorMessage = "Please select required")]
        public string Gender { get; set; }
       [Required(ErrorMessage = "Employee address is required")]
        public string Address { get; set; }
       [Required(ErrorMessage = "Your city is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Your sate is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Postal code is required")]
        [Range(0, 99999)]
        [Display(Name ="Zip Code", Description ="Enter only numeric values for Zip code")]
        public string Pin { get; set; }

        public EmployeesModel(int id, string first_Name, string last_Name, string email_id, DateTime dob, string gender, string address, string city, string state, string pin)
        {
            this.ID = id;
            this.First_Name = first_Name;
            this.Last_Name = last_Name;
            this.Email = email_id;
            this.Dob = dob;
            this.Gender = gender;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Pin = pin;

        }


    }
}