using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcBaseDemo.DAL;

namespace MvcBaseDemo.Areas.Test.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            //List<Employee> employees = new List<Employee>();
            //Employee emp = new Employee();
            //emp.LastName = "johnson";
            //emp.LastName = "fernandes";
            //emp.Salary = 14000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "michael";
            //emp.LastName = "jackson";
            //emp.Salary = 16000;
            //employees.Add(emp);

            //emp = new Employee();
            //emp.FirstName = "robert";
            //emp.LastName = "pattinson";
            //emp.Salary = 20000;
            //employees.Add(emp);

            //return employees;
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }
        
    }
}