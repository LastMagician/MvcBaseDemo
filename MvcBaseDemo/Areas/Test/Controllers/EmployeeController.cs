using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBaseDemo.Areas.Test.Models;
using MvcBaseDemo.Areas.Test.ViewModels;
using MvcBaseDemo.DAL;

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

    public class EmployeeController : Controller
    {
        //
        // GET: /Test/Test/

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

        public string ReturnStr()
        {
            return "Ths";
        }

        public ActionResult Index()
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

            //employeeListViewModel.UserName = "Admin";-->Remove this line -->Change1
            return View("Index", employeeListViewModel);//-->Change View Name -->Change 2
        }


        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    //Employee e = new Employee();
                    //e.FirstName = Request.Form["FName"];
                    //e.LastName = Request.Form["LName"];
                    //e.Salary = int.Parse(Request.Form["Salary"]);

                    //SalesERPDAL saleDal = new SalesERPDAL();
                    //saleDal.SaveEmployee(e);
                    //return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                    if (ModelState.IsValid)
                    {
                        //Employee e = new Employee();
                        //e.FirstName = Request.Form["FirstName"];
                        //e.LastName = Request.Form["LastName"];
                        //e.Salary = int.Parse(Request.Form["Salary"]);

                        SalesERPDAL saleDal = new SalesERPDAL();
                        saleDal.SaveEmployee(e);
                        return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                    }
                    else
                    {
                        //return Content(ModelState.IsValid.ToString());
                        return View("CreateEmployee");
                    }
                case "Cancel":
                    // 有bug，跳转地址错误
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }
}
