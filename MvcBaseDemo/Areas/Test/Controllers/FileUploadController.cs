using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBaseDemo.Areas.Test.Controllers
{
    public class FileUploadController : Controller
    {
        //
        // GET: /Test/FileUpload/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BaseMethod(HttpPostedFileBase uploadFile)
        {
            if (uploadFile.ContentLength > 0)
            {
                string filePath = Path.Combine(
                    HttpContext.Server.MapPath("../Uploads"), 
                    Path.GetFileName(uploadFile.FileName)
                );
                uploadFile.SaveAs(filePath);
            }
            return View();
        }
    }
}
