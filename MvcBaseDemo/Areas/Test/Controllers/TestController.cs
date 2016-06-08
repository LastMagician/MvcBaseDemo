using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBaseDemo.Areas.Test.Models;
using MvcBaseDemo.Areas.Test.ViewModels;

namespace MvcBaseDemo.Areas.Test.Controllers
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return this.CustomerName + "|" + this.Address;
        }
    }

    public class TestController : Controller
    {
        //
        // GET: /Test/Test/

        public ActionResult Index()
        {

            return View();
        }

        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "Customer 1";
            c.Address = "Address 1";
            return c;
        }

        // not Action Method defind
        [NonAction]
        public string SimpleMethod()
        {
            return "Hi, I am not";
        }

        public ActionResult GetView()
        {
            //Employee emp = new Employee();
            //emp.FirstName = "Sukesh";
            //emp.LastName = "Marla";
            //emp.Salary = 20000;

            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.EmployeeName = emp.FirstName + "  " + emp.LastName;
            //vmEmp.Salary = emp.Salary.ToString("C");
            //if (emp.Salary > 15000)
            //{
            //    vmEmp.SalaryColor = "yellow";
            //}
            //else
            //{
            //    vmEmp.SalaryColor = "green";
            //}
            //vmEmp.UserName = "Admin";

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();
            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }

            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = "Admin";
            
            return View("MyView", employeeListViewModel);      
            

        }
    }
}
