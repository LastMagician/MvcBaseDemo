using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBaseDemo.Areas.Test.Models;

namespace MvcBaseDemo.Areas.Test.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/Test/

        public string Index()
        {
            var str = "This is a test";
            var intvar = 1;
            var doublevar = 12.32;
            User user = new User()
            {
                Id = 132,
                Name = "Tshi",
                Age = 32
            };

            List<User> userList = new List<User>{
                new User{Id=1,Name="YJingLee", Age=22},
                new User{Id=2,Name="XieQing",Age=25}
            };
            userList.Add(user);
            //获取特定人时所用的过滤条件，p参数属于User类型
            var result = userList.Where(p => p.Name == "Tshi").ToList();
            var average = userList.Average(p => p.Age);
            
            string firstname = userList.First(p=>p.Age>22).Name;
            return "This is a Test"+"<br/>"+user.Id+":"+user.Name+":"+user.Age;
        }
         
    }
}
