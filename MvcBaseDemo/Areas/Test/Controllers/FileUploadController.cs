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
        private string DirName = "../../Uploads";
        //
        // GET: /Test/FileUpload/


        public ActionResult Index()
        {
            return View();
        }

        #region MVC最基本的上传文件是通过form表单提交方式
        public ActionResult UploadView()
        {
            return View("UploadView");
        }

        //MVC最基本的上传文件是通过form表单提交方式
        [HttpPost]
        public ActionResult BaseMethod(HttpPostedFileBase uploadFile)
        {
            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                string pathForSaving = Server.MapPath(DirName);
                if (this.CreateFolderIfNeeded(pathForSaving))
                {
                    //获得保存路径
                    string filePath = Path.Combine(
                        HttpContext.Server.MapPath(DirName),
                        Path.GetFileName(uploadFile.FileName)
                    );
                    uploadFile.SaveAs(filePath);
                    ViewBag.FilePath = HttpContext.Server.MapPath(DirName+"/" + uploadFile.FileName); 
                }
            }
            return View();
        }
        #endregion

        #region 使用JQuery文件上传插件实现异步上传
        //Content Page
        public ActionResult JUFIndex()
        {
            return View();
        }

        //使用JQuery文件上传插件实现异步上传
        [HttpPost]
        public ActionResult JqueryUploadFile()
        {
            HttpPostedFileBase myFile = Request.Files["MyFile"];
            bool isUploaded = false;
            string message = "上传失败";

            if (myFile != null && myFile.ContentLength != 0)
            {
                string pathForSaving = Server.MapPath(DirName);
                if (this.CreateFolderIfNeeded(pathForSaving))
                {
                    try
                    {
                        myFile.SaveAs(Path.Combine(pathForSaving, myFile.FileName));
                        isUploaded = true;
                        message = "上传成功";
                    }
                    catch (Exception ex)
                    {
                        message = string.Format("上传文件失败：{0}", ex.Message);
                    }
                }
            }
            return Json(new { isUploaded = isUploaded, message = message });
        }
        #endregion

        #region 上传多个文件
        //首页Content页
        public ActionResult MultiUploadIndex()
        {
            return View();
        }

        //上传多个文件
        public string MultiUpload(IEnumerable<HttpPostedFileBase> files)
        {
            string pathForSaving = Server.MapPath(DirName);
            string result = "上传失败";
            if (this.CreateFolderIfNeeded(pathForSaving))
            {
                foreach (var file in files)
                {
                    if (file != null)
                    {
                        try
                        {
                            var path = Path.Combine(pathForSaving, file.FileName);
                            file.SaveAs(path);
                            result = "上传成功";

                        }
                        catch (Exception)
                        {
                            result = "上传失败";
                        }
                    }    
                }
            }
            return result;
            //return RedirectToAction("Index");
        }
        #endregion

        #region 检查是否要创建上传文件夹
        /// <summary>
        /// 检查是否要创建上传文件夹
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {

                    //TODO: 处理异常
                    result = false;
                }
            }
            return result;
        }
        #endregion
        
        #region test
        //test
        public string ReturnPath()
        {
            return HttpContext.Server.MapPath("../../Uploads");
        }
        #endregion
    }
}
