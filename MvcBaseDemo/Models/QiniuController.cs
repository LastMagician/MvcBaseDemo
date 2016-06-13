using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.IO;

namespace MvcBaseDemo.Models
{
    public class QiniuController : Controller
    {
        private string path = @"E:\Users\Administrator\Pictures\Qiniu\1.jpg";
        //
        // GET: /Qiniu/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPic()
        {
            QiniuFun qiniuFun = new QiniuFun();
            qiniuFun.init();

            HttpPostedFileBase file = Request.Files["file"];

            //var filenmae = string.Format("{0:yyyyMMddHHmmssfffffff}", DateTime.Now) + ".jpg";

            //qiniuFun.UploadFile(qiniuFun.qnSpace, qiniuFun.fullname("/" + filenmae), path);
            //var name = qiniuFun.outlink + qiniuFun.fullname("/" + filenmae);
            //return Json("Success|" + name);

            Response.Write("文件统计 : "+Request.Files.Count);

            ViewBag.test = Request.Form["test1"];
            if (file != null)
            {
                var filenmae = string.Format("{0:yyyyMMddHHmmssfffffff}", DateTime.Now) + ".jpg";

                string filePath = Path.Combine(HttpContext.Server.MapPath("Images/Uploads"), Path.GetFileName(filenmae));
                file.SaveAs(filePath);

                qiniuFun.UploadFile(qiniuFun.qnSpace, qiniuFun.fullname("/" + filenmae), filePath);
                var name = qiniuFun.outlink + qiniuFun.fullname("/" + filenmae);

                return Json("Success|" + name);
            }
            else
            {
                return View();
            }
        }

    }
}
