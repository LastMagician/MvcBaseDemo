using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using MvcBaseDemo.Areas.Test.Models;

namespace MvcBaseDemo.DAL
{
    public class SalesERPDAL:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public SalesERPDAL()
            : base("name=NewName")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TbEmployee");
            base.OnModelCreating(modelBuilder);
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
    }
}