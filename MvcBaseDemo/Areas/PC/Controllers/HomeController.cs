using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBaseDemo.Areas.PC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /PC/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
